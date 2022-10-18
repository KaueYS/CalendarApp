using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using PowerCalendar.Infrastructure.Data.RepositoryContract;
using PowerCalendar.Infrastructure.Data.RepositoryServiceSqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PowerCalendar.Infrastructure.Data.RepositorySqlServer
{
    public class RepositorySqlServer : IRepository
    {
        private const string SQL_SELECT_IDENTITY = "SELECT @@IDENTITY";
        private const string SQL_GET_SQLSERVER_VERSION = "SELECT LEFT(cast(SERVERPROPERTY('ProductVersion') as varchar),4)";
        private IDbTransaction _transaction = null;
        private string _connectionString = null;
        private readonly IConfiguration _configuration;

        public RepositorySqlServer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private void InsertParameters(SqlCommand command, List<IDbDataParameter> parameters = null, bool allowInjectParameters = false, bool allowInjectParametersDeclare = true)
        {
            if (parameters == null)
                return;
            StringBuilder sqlDeclare = new StringBuilder();
            bool canInjectParameters = (allowInjectParameters) && (this.CanInjectParameters(parameters, allowInjectParametersDeclare));
            for (int i = parameters.Count - 1; i >= 0; i--)
            {
                IDbDataParameter parameter = parameters[i];
                if ((canInjectParameters) && (this.CanInjectParameterType(parameter.DbType)))
                {
                    if (allowInjectParametersDeclare)
                    {
                        sqlDeclare.AppendLine($"DECLARE {parameter.ParameterName} AS {GetParameterType(parameter.DbType)} = {parameter.Value};");
                    }
                    else
                    {
                        command.CommandText = command.CommandText.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                }
                else
                {
                    SqlParameter parameterSQL = command.CreateParameter();
                    parameterSQL.ParameterName = parameter.ParameterName;
                    parameterSQL.Value = parameter.Value;
                    parameterSQL.DbType = parameter.DbType;
                    command.Parameters.Add(parameterSQL);
                }
            }
            if (sqlDeclare.Length > 0)
                command.CommandText = sqlDeclare.ToString() + System.Environment.NewLine + command.CommandText;
        }

        private bool CanInjectParameters(List<IDbDataParameter> parameters, bool allowInjectParametersDeclare)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                IDbDataParameter parameter = parameters[i];
                if ((allowInjectParametersDeclare) && (!this.CanInjectParameterType(parameter.DbType)))
                    return (false);
                for (int j = 0; j < parameters.Count; j++)
                {
                    if (i == j)
                        continue;
                    IDbDataParameter parameterCheck = parameters[j];
                    if (parameter.ParameterName.Contains(parameterCheck.ParameterName))
                        return (false);
                }
            }
            return (true);
        }

        private bool CanInjectParameterType(DbType type)
        {
            if (type == DbType.Int32)
                return (true);
            if (type == DbType.Int64)
                return (true);
            return (false);
        }

        private string GetParameterType(DbType type)
        {
            if (type == DbType.Int32)
                return ("INT");
            if (type == DbType.Int64)
                return ("BIGINT");
            return (string.Empty);
        }

        public async Task<IDataReader> GetReader(string sql, List<IDbDataParameter> parameters = null)
        {
            SqlConnection connection = CreateConnectionInternal(true);
            try
            {
                bool isConnectionScoped = this.IsConnectionScoped(connection);
                using (SqlCommand command = CreateCommandInternal(sql, connection))
                {
                    InsertParameters(command, parameters, true);
                    SqlDataReader reader = await command.ExecuteReaderAsync(isConnectionScoped ? CommandBehavior.Default : CommandBehavior.CloseConnection);
                    return (reader);
                }
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        public IDataReader GetReaderSync(string sql, List<IDbDataParameter> parameters = null)
        {
            SqlConnection connection = CreateConnectionInternal(true);
            try
            {
                bool isConnectionScoped = this.IsConnectionScoped(connection);
                using (SqlCommand command = CreateCommandInternal(sql, connection))
                {
                    InsertParameters(command, parameters, true);
                    SqlDataReader reader = command.ExecuteReader(isConnectionScoped ? CommandBehavior.Default : CommandBehavior.CloseConnection);
                    return (reader);
                }
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        public async Task<IDataReader> GetReader(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null)
        {
            SqlTransaction transactionSQL = transaction as SqlTransaction;
            using (SqlCommand command = CreateCommandInternal(sql, transactionSQL.Connection, transactionSQL))
            {
                InsertParameters(command, parameters);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                return (reader);
            }
        }

        public async Task<TReturn> ExecuteScalar<TReturn>(string sql, List<IDbDataParameter> parameters = null)
        {
            SqlConnection connection = CreateConnectionInternal(true);
            try
            {
                using (SqlCommand command = CreateCommandInternal(sql, connection))
                {
                    InsertParameters(command, parameters);
                    TReturn scalar = ConvertTo<TReturn>(await command.ExecuteScalarAsync());
                    return (scalar);
                }
            }
            finally
            {
                this.CloseConnection(connection);
            }
        }

        public async Task<TReturn> ExecuteScalar<TReturn>(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null)
        {
            SqlTransaction transactionSQL = transaction as SqlTransaction;
            using (SqlCommand command = CreateCommandInternal(sql, transactionSQL.Connection, transactionSQL))
            {
                InsertParameters(command, parameters);
                TReturn scalar = ConvertTo<TReturn>(await command.ExecuteScalarAsync());
                return (scalar);
            }
        }

        private T ConvertTo<T>(object obj)
        {
            try
            {
                if (obj == null)
                    return (default(T));
                return ((T)Convert.ChangeType(obj, typeof(T)));
            }
            catch
            {
                return (default(T));
            }

        }

        public async Task<long> ExecuteNonQuery(string sql, List<IDbDataParameter> parameters = null)
        {
            SqlConnection connection = CreateConnectionInternal(true);
            try
            {
                using (SqlCommand command = CreateCommandInternal(sql, connection))
                {
                    InsertParameters(command, parameters);
                    long affected = await command.ExecuteNonQueryAsync();
                    return (affected);
                }
            }
            finally
            {
                this.CloseConnection(connection);
            }
        }

        public async Task<long> ExecuteNonQuery(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null)
        {
            SqlTransaction transactionSQL = transaction as SqlTransaction;
            using (SqlCommand command = CreateCommandInternal(sql, transactionSQL.Connection, transactionSQL))
            {
                InsertParameters(command, parameters);
                long affected = await command.ExecuteNonQueryAsync();
                return (affected);
            }
        }

        public async Task<long> ExecuteNonQueryIdentity(string sql, List<IDbDataParameter> parameters = null)
        {
            long? affected = null;
            SqlConnection connection = CreateConnectionInternal(true);
            try
            {
                long identity = 0;
                if (this.IsConnectionScoped(connection))
                {
                    using (SqlCommand command = CreateCommandInternal(sql, connection))
                    {
                        InsertParameters(command, parameters);
                        affected = await command.ExecuteNonQueryAsync();
                        identity = await GetServerIdentity(command.Transaction);
                    }
                }
                else
                {
                    using (SqlTransaction transaction = this.CreateTransaction(connection) as SqlTransaction)
                    {
                        using (SqlCommand command = CreateCommandInternal(sql, connection, transaction))
                        {
                            InsertParameters(command, parameters);
                            affected = await command.ExecuteNonQueryAsync();
                        }
                        identity = await GetServerIdentity(transaction);
                        transaction.Commit();
                    }
                }
                return (identity);
            }
            finally
            {
                this.CloseConnection(connection);

            }
        }

        public async Task<long> ExecuteNonQueryIdentity(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null)
        {
            long? affected = null;
            SqlTransaction transactionSQL = transaction as SqlTransaction;
            using (SqlCommand command = CreateCommandInternal(sql, transactionSQL.Connection, transactionSQL))
            {
                InsertParameters(command, parameters);
                affected = await command.ExecuteNonQueryAsync();
            }
            long identity = await GetServerIdentity(transaction);
            return (identity);
        }

        private async Task<long> GetServerIdentity(IDbTransaction transaction)
        {
            SqlTransaction transactionSQL = transaction as SqlTransaction;
            using (SqlCommand command = CreateCommandInternal(SQL_SELECT_IDENTITY, transactionSQL.Connection, transactionSQL))
            {
                return (long.Parse((await command.ExecuteScalarAsync()).ToString()));
            }
        }

        public IDbConnection CreateConnection()
        {
            return (this.CreateConnectionInternal(false));
        }

        private SqlConnection CreateConnectionInternal(bool canUseScope)
        {
            if ((canUseScope) && (this._transaction != null))
                return (this._transaction.Connection as SqlConnection);
            //if (this._connectionString == null)
            //    this._connectionString = _domainService.GetConnectionString();
            this._connectionString = this._configuration.GetConnectionString("connectionString");
            SqlConnection connection = new SqlConnection(this._connectionString);
            if (canUseScope)
                connection.Open();
            return (connection);
        }

        private void CloseConnection(SqlConnection connection)
        {
            if ((this._transaction != null) && (this._transaction.Connection == connection))
                return;
            if (connection.State != ConnectionState.Open)
                return;
            connection.Close();
        }

        private bool IsConnectionScoped(SqlConnection connection)
        {
            if ((this._transaction != null) && (this._transaction.Connection == connection))
                return (true);
            return (false);
        }

        private SqlCommand CreateCommandInternal(string sql, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (this.IsConnectionScoped(connection))
                command.Transaction = this._transaction as SqlTransaction;
            command.CommandTimeout = 0;
            return (command);
        }

        private SqlCommand CreateCommandInternal(string sql, SqlConnection connection, SqlTransaction transaction)
        {
            SqlCommand command = new SqlCommand(sql, connection, transaction);
            command.CommandTimeout = 0;
            return (command);
        }

        public IDbDataParameter CreateParameter(string name, DbType type, object value = null)
        {
            SqlParameter parameterSQL = new SqlParameter();
            parameterSQL.ParameterName = name;
            parameterSQL.Value = (value == null) ? DBNull.Value : value;
            parameterSQL.DbType = type;
            return (parameterSQL);
        }

        public IDbTransaction CreateTransaction(IDbConnection connection)
        {
            if ((this._transaction != null) && (this._transaction.Connection == connection))
                return (this._transaction);
            return (connection.BeginTransaction());
        }

        public void Commit(IDbTransaction transaction)
        {
            IDbTransaction transactionCurrent = transaction ?? _transaction;
            if (transactionCurrent == null)
                return;
            if (transactionCurrent.Connection.State != ConnectionState.Open)
                return;
            IDbConnection connection = transactionCurrent.Connection;
            transactionCurrent.Commit();
            if (_transaction == transactionCurrent)
            {
                connection.Close();
                _transaction = null;
            }
        }

        public void Rollback(IDbTransaction transaction)
        {
            IDbTransaction transactionCurrent = transaction ?? _transaction;
            if (transactionCurrent == null)
                return;
            if (transactionCurrent.Connection == null)
                return;
            if (transactionCurrent.Connection.State != ConnectionState.Open)
                return;
            IDbConnection connection = transactionCurrent.Connection;
            transactionCurrent.Rollback();
            if (_transaction == transactionCurrent)
            {
                connection.Close();
                _transaction = null;
            }
        }

        public ITransactionScope CreateTransactionScope()
        {
            bool hasState = this._transaction == null;
            if (hasState)
                this._transaction = this.CreateTransaction(this.CreateConnectionInternal(true));
            TransactionScopeSqlServer transactionScope = new TransactionScopeSqlServer(this, hasState, false);
            return (transactionScope);
        }

        public ITransactionScope CreateEmptyScope()
        {
            bool hasState = this._transaction != null;
            if (hasState)
            {
                //Commit
                if (_transaction.Connection.State == ConnectionState.Open)
                {
                    IDbConnection connection = _transaction.Connection;
                    _transaction.Commit();
                    connection.Close();
                    _transaction = null;
                }
            }
            TransactionScopeSqlServer transactionScope = new TransactionScopeSqlServer(this, false, hasState);
            return (transactionScope);
        }

        public IDbTransaction EnsureTransaction()
        {
            if (this._transaction == null)
                this._transaction = this.CreateTransaction(this.CreateConnectionInternal(true));
            return (this._transaction);
        }

        public async Task<bool> Exist(string tableOrView, IDbTransaction transaction = null)
        {
            string sql = $"IF EXISTS ( SELECT * FROM sysobjects WHERE id = object_id(N'[{tableOrView}]')) SELECT 1 AS TableOrView ELSE SELECT 0 AS TableOrView";
            if (transaction == null)
                return (await ExecuteScalar<int>(sql) > 0);
            int exist = await ExecuteScalar<int>(transaction, sql);
            return (exist > 0);
        }

        public async Task<bool> ExistColumn(string tableOrView, string columnName, IDbTransaction transaction = null)
        {
            string sql = "IF  EXISTS ( SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + tableOrView + "' AND column_name = '" + columnName + "') SELECT 1 AS result ELSE SELECT 0 AS result";
            if (transaction == null)
                return (await ExecuteScalar<int>(sql) > 0);
            int exist = await ExecuteScalar<int>(transaction, sql);
            return (exist > 0);
        }

        public async Task<bool> CreateOrUpdateView(string viewName, string viewContent, bool schemaBinding = false)
        {
            string sql = $"CREATE VIEW [{viewName}] {(schemaBinding ? "WITH SCHEMABINDING" : string.Empty)} AS {viewContent}";
            if (!await Exist(viewName))
            {
                await this.ExecuteNonQuery(sql);
                return (true);
            }
            string viewDefinition = await GetViewDefinition(viewName);
            if (sql == viewDefinition)
                return (false);
            string sqlAlter = $"ALTER VIEW [{viewName}] {(schemaBinding ? "WITH SCHEMABINDING" : string.Empty)} AS {viewContent}";
            await this.ExecuteNonQuery(sqlAlter);
            return (true);
        }

        public async Task<int> GetLengthColumn(string tableOrView, string columnName)
        {
            const string Param_tableName = "@tableName";
            const string Param_columnName = "@columnName";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(this.CreateParameter(Param_tableName, DbType.String, tableOrView));
            parameters.Add(this.CreateParameter(Param_columnName, DbType.String, columnName));
            string sql_length_column = $"SELECT CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = {Param_tableName} AND column_name = {Param_columnName}";
            return await ExecuteScalar<int>(sql_length_column, parameters);
        }

        public async Task<string> GetConstrainName(string tableOrView, string columnName)
        {
            const string Param_tableName = "@tableName";
            const string Param_columnName = "@columnName";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(this.CreateParameter(Param_tableName, DbType.String, tableOrView));
            parameters.Add(this.CreateParameter(Param_columnName, DbType.String, columnName));
            string sql_select_constraint_name = $@"SELECT CON.[NAME] AS CONSTRAINT_NAME
                            FROM SYS.DEFAULT_CONSTRAINTS CON
                                LEFT OUTER JOIN SYS.OBJECTS T
                                    ON CON.PARENT_OBJECT_ID = T.OBJECT_ID
                                LEFT OUTER JOIN SYS.ALL_COLUMNS COL
                                    ON CON.PARENT_COLUMN_ID = COL.COLUMN_ID
                                    AND CON.PARENT_OBJECT_ID = COL.OBJECT_ID
		                            WHERE T.[NAME] = {Param_tableName}
		                              AND COL.[NAME] =  {Param_columnName}";
            return await ExecuteScalar<string>(sql_select_constraint_name, parameters);
        }

        private async Task<string> GetViewDefinition(string viewName)
        {
            string sql = $"SELECT OBJECT_DEFINITION(object_id) FROM sys.views WHERE name = '{viewName}'";
            return (await this.ExecuteScalar<string>(sql));
        }

        public async Task<bool> EnsureIndex(string table, string indexName, string indexSQL)
        {
            if (await this.ExistIndex(table, indexName))
                return (false);
            await this.ExecuteNonQuery(indexSQL);
            return (true);
        }

        private async Task<bool> ExistIndex(string table, string indexName)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'{0}')", table);
            sql.AppendFormat(" AND name = N'{0}')", indexName);
            sql.AppendLine(" select 1 as retorno else select 0 as retorno");
            return (await this.ExecuteScalar<int>(sql.ToString()) > 0);
        }

        public async Task<List<string>> GetTablesName()
        {
            const string SQL_GET_TABLES_AND_VIEWS_NAME = "SELECT tableName FROM (SELECT tbl.name AS tableName FROM sys.tables AS tbl WHERE (CAST(case when tbl.is_ms_shipped = 1 then 1 WHEN (SELECT major_id FROM sys.extended_properties WHERE major_id = tbl.object_id AND minor_id = 0 AND class = 1 AND name = N'microsoft_database_tools_support') IS NOT NULL THEN 1 else 0 END AS bit) = 0) UNION ALL SELECT tbl.name AS tableName FROM sys.views AS tbl WHERE (CAST(CASE WHEN tbl.is_ms_shipped = 1 THEN 1 WHEN (SELECT major_id FROM sys.extended_properties WHERE major_id = tbl.object_id AND minor_id = 0 AND class = 1 AND name = N'microsoft_database_tools_support') IS NOT NULL THEN 1 ELSE 0 END AS bit) = 0)) a ORDER BY tableName ASC ";

            List<string> tablesName = new List<string>();
            using (IDataReader reader = await this.GetReader(SQL_GET_TABLES_AND_VIEWS_NAME))
            {
                while (reader.Read())
                    tablesName.Add(reader.GetString(0));
                reader.Close();
            }
            return tablesName;
        }

        public async Task<List<string>> GetColumnsName(string tableName)
        {
            const string Param_TableName = "@tableName";
            string SQL_COLUMNS_BY_TABLENAME = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = {Param_TableName}";

            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            List<string> columnsName = new List<string>();
            parameters.Add(this.CreateParameter(Param_TableName, DbType.String, tableName));
            using (IDataReader reader = await this.GetReader(SQL_COLUMNS_BY_TABLENAME, parameters))
            {
                while (reader.Read())
                    columnsName.Add(reader.GetString(0));
                reader.Close();
            }
            return columnsName;
        }

        public async Task<bool> WriteBulkCopy(string destinationTableName, DataTable data)
        {
            using (ITransactionScope transactionScope = this.CreateTransactionScope())
            {
                try
                {
                    IDbTransaction transaction = this._transaction;
                    using (var sqlCopy = new SqlBulkCopy(transaction.Connection as SqlConnection, SqlBulkCopyOptions.Default, transaction as SqlTransaction))
                    {
                        sqlCopy.BulkCopyTimeout = 0;
                        sqlCopy.DestinationTableName = destinationTableName;
                        sqlCopy.BatchSize = 500;
                        await sqlCopy.WriteToServerAsync(data);
                    }
                }
                catch
                {
                    transactionScope.Rollback();
                    throw;
                }
            }
            return (true);
        }

        public async Task RemoveTable(string tableName)
        {
            if (await Exist(tableName))
            {
                string sql = "DROP TABLE " + tableName;
                await ExecuteNonQuery(sql);
            }
        }

        public async Task RemoveView(string viewName)
        {
            if (await Exist(viewName))
            {
                string sql = "DROP VIEW " + viewName;
                await ExecuteNonQuery(sql);
            }
        }

        public Task<string> GetVersion()
        {
            return ExecuteScalar<string>(SQL_GET_SQLSERVER_VERSION);
        }
    }
}

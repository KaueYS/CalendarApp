using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PowerCalendar.Infrastructure.Data.RepositoryContract
{
    public interface IRepository
    {
        Task<IDataReader> GetReader(string sql, List<IDbDataParameter> parameters = null);
        IDataReader GetReaderSync(string sql, List<IDbDataParameter> parameters = null);
        Task<IDataReader> GetReader(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null);
        Task<TReturn> ExecuteScalar<TReturn>(string sql, List<IDbDataParameter> parameters = null);
        Task<TReturn> ExecuteScalar<TReturn>(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null);
        Task<long> ExecuteNonQuery(string sql, List<IDbDataParameter> parameters = null);
        Task<long> ExecuteNonQuery(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null);
        Task<long> ExecuteNonQueryIdentity(string sql, List<IDbDataParameter> parameters = null);
        Task<long> ExecuteNonQueryIdentity(IDbTransaction transaction, string sql, List<IDbDataParameter> parameters = null);
        IDbConnection CreateConnection();
        IDbDataParameter CreateParameter(string name, DbType type, object value = null);
        IDbTransaction CreateTransaction(IDbConnection connection);
        ITransactionScope CreateTransactionScope();
        ITransactionScope CreateEmptyScope();
        IDbTransaction EnsureTransaction();
        void Commit(IDbTransaction transaction);
        void Rollback(IDbTransaction transaction);
        Task<bool> Exist(string tableOrView, IDbTransaction transaction = null);
        Task<bool> ExistColumn(string tableOrView, string columnName, IDbTransaction transaction = null);
        Task<int> GetLengthColumn(string tableOrView, string columnName);
        Task<string> GetConstrainName(string tableOrView, string columnName);
        Task<bool> CreateOrUpdateView(string viewName, string viewContent, bool schemaBinding = false);
        Task<bool> EnsureIndex(string table, string indexName, string indexSQL);
        Task<List<string>> GetTablesName();
        Task<List<string>> GetColumnsName(string tableName);
        Task<bool> WriteBulkCopy(string destinationTableName, DataTable data);
        Task RemoveTable(string tableName);
        Task RemoveView(string viewName);
        Task<string> GetVersion();
    }
}

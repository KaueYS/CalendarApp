using PowerCalendar.Infrastructure.Data.RepositoryContract;
using System.Collections.Generic;
using System;
using System.Data;
using System.Threading.Tasks;
using WebMVC.Contract;
using WebMVC.DTO;

namespace WebMVC.Service
{
    public class SecurityRoleService : ISecurityRoleService
    {
        private readonly IRepository _repository;

        public SecurityRoleService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RoleVO>> GetRoles(long codUser)
        {
            try
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                this.AddParameterCodUser(parameters, codUser);

                RoleVO? role = null;
                List<RoleVO> roles = new List<RoleVO>();
                using (IDbConnection connection = _repository.CreateConnection())
                {
                    connection.Open();
                    using (IDataReader reader = await _repository.GetReader(SQL_SELECT_T_USER_ROLE_BY_CODUSER, 
                        parameters))
                    {
                        while (reader.Read())
                        {
                            role = this.CreateRole(reader);
                            roles.Add(role);
                        }
                    }
                }
                return roles;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private const string SQL_SELECT_T_USER_ROLE_BY_CODUSER = @"SELECT R.codRole, R.dscRole FROM T_USER U
            Inner join T_USER_ROLE UR on UR.codUser = U.codUser
            Inner join T_ROLE R on UR.codRole = R.codRole
            WHERE U.codUser = @codUser";

        private const string PARAM_codUser = "@codUser";

        private void AddParameterCodUser(List<IDbDataParameter> parameters, long codUser)
        {
            parameters.Add(this._repository.CreateParameter(PARAM_codUser, DbType.Int64, codUser));
        }


        private RoleVO CreateRole(IDataReader reader)
        {
            RoleVO role = new RoleVO();
            role.Code = reader.GetInt32(0);
            role.Description = reader.GetString(1);
            return role;
        }

        
    }
}

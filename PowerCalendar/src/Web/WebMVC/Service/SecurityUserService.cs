using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using WebMVC.Contract;
using PowerCalendar.Infrastructure.Data.RepositoryContract;
using WebMVC.DTO;

namespace WebMVC.Service
{
    public class SecurityUserService : ISecurityUserService
    {
        private readonly IRepository _repository;

        public SecurityUserService(IRepository repository)
        {
            _repository = repository;
        }

        private const string SQL_SELECT_T_USER_BY_EMAIL = "SELECT codUser, dscName, dscEmail, dscPassword, dscPhone, flgStatus, datRegister FROM T_USER WHERE dscEmail = @dscEmail";
        private const string SQL_SELECT_TUSER_ROLE_BY_CODUSER = @"SELECT R.codRole, R.dscRole FROM T_USER U
            Inner join T_USER_ROLE UR on UR.codUser = U.codUser
            Inner join T_ROLE R on UR.codRole = R.codRole
            WHERE U.codUser = @codUser";
        private void AddParameterCodUser(List<IDbDataParameter> parameters, long codUser)
        {
            parameters.Add(this._repository.CreateParameter(PARAM_codUser, DbType.Int64, codUser));
        }
        private const string PARAM_codUser = "@codUser";
        private const string PARAM_dscEmail = "@dscEmail";
        private void AddParameterEmail(List<IDbDataParameter> parameters, string email)
        {
            parameters.Add(this._repository.CreateParameter(PARAM_dscEmail, DbType.String, email));
        }

        public async Task<UserVO> Get(UserGetDTQ userGetQuery)
        {
            try
            {
                List<IDbDataParameter> parameters = new List<IDbDataParameter>();
                this.AddParameterEmail(parameters, userGetQuery.Email);

                UserVO? user = null;
                using (IDbConnection connection = _repository.CreateConnection())
                {
                    connection.Open();
                    using (IDataReader reader = await _repository.GetReader(SQL_SELECT_T_USER_BY_EMAIL, parameters))
                    {
                        if (reader.Read())
                        {
                            user = this.Create(reader);
                            user.Roles = await this.GetRoles(user.Code);
                        }
                    }
                }
                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private async Task<List<RoleVO>> GetRoles(long codUser)
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
                    using (IDataReader reader = await _repository.GetReader(SQL_SELECT_TUSER_ROLE_BY_CODUSER, parameters))
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

        private UserVO Create(IDataReader reader)
        {
            UserVO user = new UserVO();
            user.Code = reader.GetInt64(0);
            user.Name = reader.GetString(1);
            user.Email = reader.GetString(2);
            user.Phone = reader.GetString(4);
            int status = reader.GetInt32(5);
            switch (status)
            {
                case 0:
                    user.Status = UserStatusType.Inactive;
                    break;
                case 1:
                    user.Status = UserStatusType.Active;
                    break;
                default:
                    break;
            }
            user.Register = reader.GetDateTime(6);
            return user;
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

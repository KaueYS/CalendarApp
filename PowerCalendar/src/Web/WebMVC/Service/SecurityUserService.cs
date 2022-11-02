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
        private readonly ISecurityRoleService _securityRoleService;
        private readonly IRepository _repository;

        public SecurityUserService(IRepository repository, ISecurityRoleService securityRoleService)
        {
            _repository = repository;
            _securityRoleService = securityRoleService;
        }

        private const string SQL_SELECT_T_USER_BY_EMAIL = "SELECT codUser, dscName, dscEmail, dscPassword, dscPhone, flgStatus, datRegister FROM T_USER WHERE dscEmail = @dscEmail";
        
        private const string PARAM_codUser = "@codUser";
        private const string PARAM_dscEmail = "@dscEmail";
        private void AddParameterEmail(List<IDbDataParameter> parameters, string email)
        {
            parameters.Add(this._repository.CreateParameter(PARAM_dscEmail, DbType.String, email));
        }

        public async Task<AnswerDTO<UserVO>> Get(UserGetDTQ userGetQuery)
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
                            user.Roles = await this._securityRoleService.GetRoles(user.Code);
                        }
                    }
                }
                return new AnswerDTO<UserVO>(user);
            }
            catch (Exception e)
            {
                return new AnswerDTO<UserVO>(null, "Nao foi possivel acessar usuario");
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
        
    }
}

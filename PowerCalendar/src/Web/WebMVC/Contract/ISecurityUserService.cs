using System.Threading.Tasks;
using WebMVC.DTO;

namespace WebMVC.Contract
{
    public interface ISecurityUserService
    {
        Task<AnswerDTO<UserVO>> Get(UserGetDTQ userGetQuery);
    }
}

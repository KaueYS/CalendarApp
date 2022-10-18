using System.Threading.Tasks;
using WebMVC.DTO;

namespace WebMVC.Contract
{
    public interface ISecurityUserService
    {
        Task<UserVO> Get(UserGetDTQ userGetQuery);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.DTO;

namespace WebMVC.Contract
{
    public interface ISecurityRoleService
    {
        Task<List<RoleVO>> GetRoles(long codUser);
    }
}

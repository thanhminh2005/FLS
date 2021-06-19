using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleBL
    {
        Task<List<Role>> GetAllRolesAsync();

        Task<Role> GetRoleAsync(int id);

        Task<bool> CreateRoleAsync(Role role);

        Task<bool> UpdateRoleAsync(Role role);

        Task<bool> DeleteRoleAsync(int id);
    }
}
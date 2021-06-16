using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserBL
    {
        Task<List<User>> GetUsersAsync();

        Task<User> GetUserAsync(int id);

        Task<bool> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(int id);

        Task<bool> CreateUserAsync(User user);
    }
}
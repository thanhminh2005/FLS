using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentBL
    {
        Task<List<Department>> GetAllDepartmentsAsync();

        Task<Department> GetDepartmentAsync(int id);

        Task<bool> UpdateDepartmentAsync(Department department);

        Task<bool> DeleteDepartmentAsync(int id);

        Task<bool> CreateDepartmentAsync(Department department);
    }
}
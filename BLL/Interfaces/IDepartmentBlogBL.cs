using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentBlogBL
    {
        Task<List<DepartmentBlog>> GetAllDepartmentBlogsAsync();

        Task<DepartmentBlog> GetDepartmentBlogAsync(int departmentId, int blogId);

        Task<bool> UpdateDepartmentBlogAsync(DepartmentBlog blog);

        Task<bool> DeleteDepartmentBlogAsync(int departmentId, int blogId);

        Task<bool> CreateDepartmentBlogAsync(DepartmentBlog blog);
    }
}
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICourseBL
    {
        Task<List<Course>> GetAllCoursesAsync();

        Task<Course> GetCourseAsync(int id);

        Task<bool> UpdateCourseAsync(Course course);

        Task<bool> DeleteCourseAsync(int id);

        Task<bool> CreateCourseAsync(Course course);
    }
}
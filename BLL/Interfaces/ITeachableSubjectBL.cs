using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITeachableSubjectBL
    {
        Task<List<TeachableSubject>> GetAllTeachableSubjectsAsync();

        Task<TeachableSubject> GetTeachableSubjectAsync(int lecturerId, int subjectId);

        Task<bool> UpdateTeachableSubjectAsync(TeachableSubject teachable);

        Task<bool> DeleteTeachableSubjectAsync(int lecturerId, int subjectId);

        Task<bool> CreateTeachableSubjectAsync(TeachableSubject teachable);
    }
}
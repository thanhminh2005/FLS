using BLL.Queries;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubjectBL
    {
        Task<List<Subject>> GetAllSubjectsAsync(GetAllSubjectQuery query);

        Task<Subject> GetSubjectAsync(int id);

        Task<bool> UpdateSubjectAsync(Subject subject);

        Task<bool> DeleteSubjectAsync(int id);

        Task<bool> CreateSubjectAsync(Subject subject);
    }
}
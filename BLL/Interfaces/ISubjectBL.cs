using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubjectBL
    {
        Task<List<Subject>> GetAllSubjects();

        Task<Subject> GetSubject(int id);

        Task<bool> CreateSubject(Subject subject);

        Task<bool> UpdateSubject(Subject subject);
    }
}
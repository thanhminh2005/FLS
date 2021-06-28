using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISemesterPlanBL
    {
        Task<List<SemesterPlan>> GetAllSemesterPlansAsync();

        Task<SemesterPlan> GetSemesterPlanAsync(int id);

        Task<bool> UpdateSemesterPlanAsync(SemesterPlan plan);

        Task<bool> DeleteSemesterPlanAsync(int id);

        Task<bool> CreateSemesterPlanAsync(SemesterPlan plan);
    }
}

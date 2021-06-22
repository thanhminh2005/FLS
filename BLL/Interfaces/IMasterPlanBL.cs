using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMasterPlanBL
    {
        Task<List<MasterPlan>> GetAllMasterPlansAsync();

        Task<MasterPlan> GetMasterPlanAsync(int id);

        Task<bool> UpdateMasterPlanAsync(MasterPlan plan);

        Task<bool> DeleteMasterPlanAsync(int id);

        Task<bool> CreateMasterPlanAsync(MasterPlan plan);
    }
}
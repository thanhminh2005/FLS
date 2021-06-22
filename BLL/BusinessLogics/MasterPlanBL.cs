using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class MasterPlanBL : IMasterPlanBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public MasterPlanBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateMasterPlanAsync(MasterPlan plan)
        {
            await _context.MasterPlans.AddAsync(plan);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteMasterPlanAsync(int id)
        {
            var plan = new MasterPlan
            {
                Id = id
            };
            _context.MasterPlans.Attach(plan);
            _context.MasterPlans.Remove(plan);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<MasterPlan> GetMasterPlanAsync(int id)
        {
            return _context.MasterPlans.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<MasterPlan>> GetAllMasterPlansAsync()
        {
            return _context.MasterPlans.ToListAsync();
        }

        public async Task<bool> UpdateMasterPlanAsync(MasterPlan plan)
        {
            var newMasterPlan = await GetMasterPlanAsync(plan.Id);
            if (newMasterPlan != null)
            {
                newMasterPlan.Description = plan.Description;
                newMasterPlan.Name = plan.Name;
                _context.MasterPlans.Update(newMasterPlan);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
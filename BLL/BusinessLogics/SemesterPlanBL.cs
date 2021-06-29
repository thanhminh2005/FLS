using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class SemesterPlanBL : ISemesterPlanBL
    {
        private readonly FLSContext _context;

        public SemesterPlanBL(FLSContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateSemesterPlanAsync(SemesterPlan plan)
        {
            await _context.SemesterPlans.AddAsync(plan);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteSemesterPlanAsync(int id)
        {
            var plan = new SemesterPlan
            {
                Id = id
            };
            _context.SemesterPlans.Attach(plan);
            _context.SemesterPlans.Remove(plan);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<SemesterPlan>> GetAllSemesterPlansAsync()
        {
            return _context.SemesterPlans.ToListAsync();
        }

        public Task<SemesterPlan> GetSemesterPlanAsync(int id)
        {
            return _context.SemesterPlans.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateSemesterPlanAsync(SemesterPlan plan)
        {
            var newPlan = await GetSemesterPlanAsync(plan.Id);
            if (newPlan != null)
            {

                newPlan.Description = plan.Description;
                newPlan.Name = plan.Name;
                _context.SemesterPlans.Update(newPlan);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}

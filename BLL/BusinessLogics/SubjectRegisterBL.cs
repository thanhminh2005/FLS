using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class SubjectRegisterBL : ISubjectRegisterBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public SubjectRegisterBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateSubjectRegisterAsync(SubjectRegister register)
        {
            var existRegister = _context
                .SubjectRegisters
                .SingleOrDefaultAsync(x => x.LecturerId == register.LecturerId && x.SemesterPlanId == register.SemesterPlanId && x.SubjectId == register.SubjectId);
            if (existRegister == null)
            {
                await _context.SubjectRegisters.AddAsync(register);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteSubjectRegisterAsync(int id)
        {
            var register = new SubjectRegister
            {
                Id = id
            };
            _context.SubjectRegisters.Attach(register);
            _context.SubjectRegisters.Remove(register);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<SubjectRegister> GetSubjectRegisterAsync(int id)
        {
            return _context.SubjectRegisters.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<SubjectRegister>> GetAllSubjectRegistersAsync()
        {
            return _context.SubjectRegisters.ToListAsync();
        }

        public async Task<bool> UpdateSubjectRegisterAsync(SubjectRegister register)
        {
            var newRegister = await GetSubjectRegisterAsync(register.Id);
            if (newRegister != null)
            {
                newRegister.LecturerId = register.LecturerId;
                newRegister.SemesterPlanId = register.SemesterPlanId;
                newRegister.SubjectId = register.SubjectId;
                _context.SubjectRegisters.Update(newRegister);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
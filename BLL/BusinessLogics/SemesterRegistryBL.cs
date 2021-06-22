using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class SemesterRegisterBL : ISemesterRegisterBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public SemesterRegisterBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateSemesterRegisterAsync(LectureSemesterRegister register)
        {
            await _context.LectureSemesterRegisters.AddAsync(register);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteSemesterRegisterAsync(int semesterId, int lecturerId)
        {
            var register = new LectureSemesterRegister
            {
                LecturerId = lecturerId,
                SemesterId = semesterId
            };
            _context.LectureSemesterRegisters.Attach(register);
            _context.LectureSemesterRegisters.Remove(register);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<LectureSemesterRegister>> GetAllSemesterRegistersAsync()
        {
            return _context
                .LectureSemesterRegisters
                .Include(x => x.Semester)
                .Include(x => x.Lecturer)
                .ToListAsync();
        }

        public Task<LectureSemesterRegister> GetSemesterRegisterAsync(int semesterId, int lecturerId)
        {
            return _context
                .LectureSemesterRegisters
                .SingleOrDefaultAsync(x => x.SemesterId == semesterId && x.LecturerId == lecturerId);
        }

        public async Task<bool> UpdateSemesterRegisterAsync(LectureSemesterRegister register)
        {
            var newRegister = await GetSemesterRegisterAsync(register.SemesterId, register.LecturerId);
            if (newRegister != null)
            {
                newRegister.SemesterId = register.SemesterId;
                newRegister.LecturerId = register.LecturerId;
                _context.LectureSemesterRegisters.Update(newRegister);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}

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
    public class SemesterRegistryBL : ISemesterRegistryBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public SemesterRegistryBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateSemesterRegistryAsync(LectureSemesterRegister register)
        {
            await _context.LectureSemesterRegisters.AddAsync(register);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteSemesterRegistryAsync(int semesterId, int lecturerId)
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

        public Task<List<LectureSemesterRegister>> GetAllSemesterRegistrysAsync()
        {
            return _context
                .LectureSemesterRegisters
                .Include(x => x.Semester)
                .Include(x => x.Lecturer)
                .ToListAsync();
        }

        public Task<LectureSemesterRegister> GetSemesterRegistryAsync(int semesterId, int lecturerId)
        {
            return _context
                .LectureSemesterRegisters
                .SingleOrDefaultAsync(x => x.SemesterId == semesterId && x.LecturerId == lecturerId);
        }

        public async Task<bool> UpdateSemesterRegistryAsync(LectureSemesterRegister register)
        {
            var newRegister = await GetSemesterRegistryAsync(register.SemesterId, register.LecturerId);
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

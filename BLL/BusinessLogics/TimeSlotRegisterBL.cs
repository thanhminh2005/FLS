using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class TimeSlotRegisterBL : ITimeSlotRegisterBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public TimeSlotRegisterBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateTimeSlotRegisterAsync(TimeSlotRegister register)
        {
            var existRegister = await _context.TimeSlotRegisters.SingleOrDefaultAsync(x => x.LecturerId == register.LecturerId && x.SemesterPlanId == register.SemesterPlanId && x.TimeSlotId == register.TimeSlotId);
            if(existRegister == null)
            {
                await _context.TimeSlotRegisters.AddAsync(register);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteTimeSlotRegisterAsync(int id)
        {
            var TimeSlotRegister = new TimeSlotRegister
            {
                Id = id
            };
            _context.TimeSlotRegisters.Attach(TimeSlotRegister);
            _context.TimeSlotRegisters.Remove(TimeSlotRegister);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<TimeSlotRegister> GetTimeSlotRegisterAsync(int id)
        {
            return _context.TimeSlotRegisters.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<TimeSlotRegister>> GetAllTimeSlotRegistersAsync()
        {
            return _context.TimeSlotRegisters.ToListAsync();
        }

        public async Task<bool> UpdateTimeSlotRegisterAsync(TimeSlotRegister register)
        {
            var newTimeSlotRegister = await GetTimeSlotRegisterAsync(register.Id);
            if (newTimeSlotRegister != null)
            {
                newTimeSlotRegister.PreferPoint = register.PreferPoint;
                newTimeSlotRegister.TimeSlotId = register.TimeSlotId;
                newTimeSlotRegister.SemesterPlanId = register.SemesterPlanId;
                _context.TimeSlotRegisters.Update(newTimeSlotRegister);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}

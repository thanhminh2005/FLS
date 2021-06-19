using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class TimeSlotBL : ITimeSlotBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;
        private readonly TimeSpan startWorkTime = new TimeSpan(6, 0, 0);
        private readonly TimeSpan endWorkTime = new TimeSpan(21, 0, 0);

        public TimeSlotBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateTimeSlotAsync(TimeSlot slot)
        {
            if (!IsOverLap(slot.StartTime, slot.EndTime, await GetAllTimeSlotsAsync()))
            {
                await _context.TimeSlots.AddAsync(slot);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteTimeSlotAsync(int id)
        {
            var slot = new TimeSlot
            {
                Id = id
            };
            _context.TimeSlots.Attach(slot);
            _context.TimeSlots.Remove(slot);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<TimeSlot> GetTimeSlotAsync(int id)
        {
            return _context.TimeSlots.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<TimeSlot>> GetAllTimeSlotsAsync()
        {
            return _context.TimeSlots.ToListAsync();
        }

        public async Task<bool> UpdateTimeSlotAsync(TimeSlot slot)
        {
            var newTimeSlot = await GetTimeSlotAsync(slot.Id);
            if (newTimeSlot != null)
            {
                if (!IsOverLap(slot.StartTime, slot.EndTime, await GetAllTimeSlotsAsync()))
                {
                    _context.TimeSlots.Update(newTimeSlot);
                    var updated = await _context.SaveChangesAsync();
                    return updated > 0;
                }
            }
            return false;
        }

        private bool isPeriodValid(TimeSpan start, TimeSpan end)
        {
            var check = start.CompareTo(end) < 0 && start.CompareTo(startWorkTime) >= 0 && end.CompareTo(endWorkTime) <= 0;
            return check;
        }

        private bool IsOverLap(TimeSpan start, TimeSpan end, List<TimeSlot> slots)
        {
            var check = false;
            if (isPeriodValid(start, end))
            {
                check = true;
                foreach (var slot in slots)
                {
                    if (slot.StartTime.CompareTo(end) < 0 && slot.EndTime.CompareTo(start) > 0)
                    {
                        return false;
                    }
                }
            }
            return check;
        }
    }
}
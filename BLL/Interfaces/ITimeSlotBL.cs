using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITimeSlotBL
    {
        Task<List<TimeSlot>> GetAllTimeSlotsAsync();

        Task<TimeSlot> GetTimeSlotAsync(int id);

        Task<bool> UpdateTimeSlotAsync(TimeSlot slot);

        Task<bool> DeleteTimeSlotAsync(int id);

        Task<bool> CreateTimeSlotAsync(TimeSlot slot);
    }
}

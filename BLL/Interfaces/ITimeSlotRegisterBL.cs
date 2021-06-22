using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITimeSlotRegisterBL
    {
        Task<List<TimeSlotRegister>> GetAllTimeSlotRegistersAsync();

        Task<TimeSlotRegister> GetTimeSlotRegisterAsync(int id);

        Task<bool> UpdateTimeSlotRegisterAsync(TimeSlotRegister register);

        Task<bool> DeleteTimeSlotRegisterAsync(int id);

        Task<bool> CreateTimeSlotRegisterAsync(TimeSlotRegister register);
    }
}
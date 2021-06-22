using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISemesterRegisterBL
    {
        Task<List<LectureSemesterRegister>> GetAllSemesterRegistersAsync();

        Task<LectureSemesterRegister> GetSemesterRegisterAsync(int semesterId, int lecturerId);

        Task<bool> UpdateSemesterRegisterAsync(LectureSemesterRegister register);

        Task<bool> DeleteSemesterRegisterAsync(int semesterId, int lecturerId);

        Task<bool> CreateSemesterRegisterAsync(LectureSemesterRegister register);
    }
}
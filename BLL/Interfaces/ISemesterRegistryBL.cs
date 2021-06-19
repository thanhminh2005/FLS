using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISemesterRegistryBL
    {
        Task<List<LectureSemesterRegister>> GetAllSemesterRegistrysAsync();

        Task<LectureSemesterRegister> GetSemesterRegistryAsync(int semesterId, int lecturerId);

        Task<bool> UpdateSemesterRegistryAsync(LectureSemesterRegister register);

        Task<bool> DeleteSemesterRegistryAsync(int semesterId, int lecturerId);

        Task<bool> CreateSemesterRegistryAsync(LectureSemesterRegister register);
    }
}

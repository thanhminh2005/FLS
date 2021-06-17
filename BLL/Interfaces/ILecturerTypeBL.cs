using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILecturerTypeBL
    {
        Task<List<LecturerType>> GetAllLecturerTypesAsync();

        Task<LecturerType> GetLecturerTypeAsync(int id);

        Task<bool> UpdateLecturerTypeAsync(LecturerType type);

        Task<bool> DeleteLecturerTypeAsync(int id);

        Task<bool> CreateLecturerTypeAsync(LecturerType type);
    }
}

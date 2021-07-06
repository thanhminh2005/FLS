using BLL.Queries;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILecturerBL
    {
        Task<List<Lecturer>> GetAllLecturersAsync(GetAllLecturerQuery query);

        Task<Lecturer> GetLecturerAsync(int id);

        Task<Lecturer> GetLecturerByUserIdAsync(int id);

        Task<bool> UpdateLecturerAsync(Lecturer lecturer);

        Task<bool> DeleteLecturerAsync(int id);

        Task<bool> CreateLecturerAsync(Lecturer lecturer);
    }
}
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILecturerBL
    {
        Task<List<Lecturer>> GetAllLecturersAsync();

        Task<Lecturer> GetLecturerAsync(int id);

        Task<bool> UpdateLecturerAsync(Lecturer lecturer);

        Task<bool> DeleteLecturerAsync(int id);

        Task<bool> CreateLecturerAsync(Lecturer lecturer);
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISemesterBL
    {
        Task<List<Semester>> GetAllSemestersAsync();

        Task<Semester> GetSemesterAsync(int id);

        Task<bool> UpdateSemesterAsync(Semester semester);

        Task<bool> DeleteSemesterAsync(int id);

        Task<bool> CreateSemesterAsync(Semester semester);
    }
}

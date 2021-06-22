using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubjectRegisterBL
    {
        Task<List<SubjectRegister>> GetAllSubjectRegistersAsync();

        Task<SubjectRegister> GetSubjectRegisterAsync(int id);

        Task<bool> UpdateSubjectRegisterAsync(SubjectRegister register);

        Task<bool> DeleteSubjectRegisterAsync(int id);

        Task<bool> CreateSubjectRegisterAsync(SubjectRegister register);
    }
}

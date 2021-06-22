using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILecturerRatingBL
    {
        Task<List<LecturerRating>> GetAllLecturerRatingsAsync();

        Task<LecturerRating> GetLecturerRatingAsync(int semesterPlanId, int lecturerId);

        Task<bool> UpdateLecturerRatingAsync(LecturerRating rating);

        Task<bool> DeleteLecturerRatingAsync(int semesterPlanId, int lecturerId);

        Task<bool> CreateLecturerRatingAsync(LecturerRating rating);
    }
}
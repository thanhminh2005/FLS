using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class LecturerRatingBL : ILecturerRatingBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public LecturerRatingBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateLecturerRatingAsync(LecturerRating rating)
        {
            await _context
                .LecturerRatings
                .AddAsync(rating);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteLecturerRatingAsync(int semesterPlanId, int lecturerId)
        {
            var rating = new LecturerRating
            {
                LecturerId = lecturerId,
                SemesterPlanId = semesterPlanId
            };
            _context.LecturerRatings.Attach(rating);
            _context.LecturerRatings.Remove(rating);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<LecturerRating>> GetAllLecturerRatingsAsync()
        {
            return _context
                .LecturerRatings
                .Include(x => x.Lecturer)
                .Include(x => x.SemesterPlan)
                .ToListAsync();
        }

        public Task<LecturerRating> GetLecturerRatingAsync(int semesterPlanId, int lecturerId)
        {
            return _context
                .LecturerRatings
                .Include(x => x.Lecturer)
                .Include(x => x.SemesterPlan)
                .SingleOrDefaultAsync(x => x.LecturerId == lecturerId && x.SemesterPlanId == semesterPlanId);
        }

        public async Task<bool> UpdateLecturerRatingAsync(LecturerRating rating)
        {
            var newLecturerRating = await GetLecturerRatingAsync(rating.SemesterPlanId, rating.LecturerId);
            if (newLecturerRating != null)
            {
                newLecturerRating.SemesterPlanId = rating.SemesterPlanId;
                newLecturerRating.LecturerId = rating.LecturerId;
                newLecturerRating.RatePoint = rating.RatePoint;
                _context.LecturerRatings.Update(newLecturerRating);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
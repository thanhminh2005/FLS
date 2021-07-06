using AutoMapper;
using BLL.Interfaces;
using BLL.Queries;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class LecturerBL : ILecturerBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public LecturerBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateLecturerAsync(Lecturer Lecturer)
        {
            var existLecturer = await _context.Lecturers.SingleOrDefaultAsync(x => x.LecturerCode.Equals(Lecturer.LecturerCode) || x.UserId == Lecturer.UserId);
            if (existLecturer == null)
            {
                await _context.Lecturers.AddAsync(Lecturer);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteLecturerAsync(int id)
        {
            var lecturer = new Lecturer
            {
                Id = id
            };
            _context.Lecturers.Attach(lecturer);
            _context.Lecturers.Remove(lecturer);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<Lecturer> GetLecturerAsync(int id)
        {
            return _context.Lecturers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<Lecturer> GetLecturerByUserIdAsync(int id)
        {
            return _context.Lecturers.SingleOrDefaultAsync(x => x.UserId == id);
        }

        public Task<List<Lecturer>> GetAllLecturersAsync(GetAllLecturerQuery query)
        {
            var queryable = _context.Lecturers.AsQueryable();
            if(queryable != null)
            {
                if (query.DepartmentId != 0)
                {
                    queryable = queryable.Where(x => x.DepartmentId == query.DepartmentId);
                }
                if (query.LecturerTypeId != 0)
                {
                    queryable = queryable.Where(x => x.LecturerTypeId == query.LecturerTypeId);
                }
            }
            return queryable.ToListAsync();
        }

        public async Task<bool> UpdateLecturerAsync(Lecturer lecturer)
        {
            var newLecturer = await GetLecturerAsync(lecturer.Id);
            if (newLecturer != null)
            {
                newLecturer.LecturerTypeId = lecturer.LecturerTypeId;
                newLecturer.MaxCourse = lecturer.MaxCourse;
                newLecturer.MinCourse = lecturer.MinCourse;
                newLecturer.PriorityPoint = lecturer.PriorityPoint;
                newLecturer.Status = lecturer.Status;
                _context.Lecturers.Update(newLecturer);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
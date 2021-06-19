using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var existLecturer = await _context.Lecturers.SingleOrDefaultAsync(x => x.LecturerCode.Equals(Lecturer.LecturerCode));
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

        public Task<List<Lecturer>> GetAllLecturersAsync()
        {
            return _context.Lecturers.ToListAsync();
        }

        public async Task<bool> UpdateLecturerAsync(Lecturer lecturer)
        {
            var newLecturer = await _context.Lecturers.SingleOrDefaultAsync(x => x.Id == lecturer.Id);
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
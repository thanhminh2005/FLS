using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class CourseBL : ICourseBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public CourseBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = new Course
            {
                Id = id
            };
            _context.Courses.Attach(course);
            _context.Courses.Remove(course);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<Course> GetCourseAsync(int id)
        {
            return _context.Courses.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Course>> GetAllCoursesAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            var newCourse = await _context.Courses.SingleOrDefaultAsync(x => x.Id == course.Id);
            if (newCourse != null)
            {
                newCourse.Name = course.Name;
                newCourse.SemesterId = course.SemesterId;
                newCourse.SubjectId = course.SubjectId;
                _context.Courses.Update(newCourse);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
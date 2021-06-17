using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class SemesterBL : ISemesterBL
    {

        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public SemesterBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateSemesterAsync(Semester semester)
        {
            var existSemester = await _context.Semesters.SingleOrDefaultAsync(x => x.Name.Equals(semester.Name));
            if(existSemester == null)
            {
                if (semester.StartDate.CompareTo(semester.EndDate) < 0)
                {
                    await _context.Semesters.AddAsync(semester);
                    var created = await _context.SaveChangesAsync();
                    return created > 0;
                }
            }
            return false;
        }

        public async Task<bool> DeleteSemesterAsync(int id)
        {
            var semester = new Semester
            {
                Id = id
            };
            _context.Semesters.Attach(semester);
            _context.Semesters.Remove(semester);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<Semester> GetSemesterAsync(int id)
        {
            return _context.Semesters.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Semester>> GetAllSemestersAsync()
        {
            return _context.Semesters.ToListAsync();
        }

        public async Task<bool> UpdateSemesterAsync(Semester semester)
        {
            var newSemester = await _context.Semesters.SingleOrDefaultAsync(x => x.Id == semester.Id);
            if (newSemester != null)
            {
                if (semester.StartDate.CompareTo(semester.EndDate) < 0)
                {
                    newSemester.StartDate = semester.StartDate;
                    newSemester.EndDate = semester.EndDate;
                    newSemester.Name = semester.Name;
                    _context.Semesters.Update(newSemester);
                    var updated = await _context.SaveChangesAsync();
                    return updated > 0;
                }
            }
            return false;
        }
    }
}

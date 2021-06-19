using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class SubjectBL : ISubjectBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public SubjectBL(IMapper mapper, FLSContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateSubjectAsync(Subject subject)
        {
            var existSubject = await _context.Subjects.SingleOrDefaultAsync(x => x.SubjectCode.Equals(subject.SubjectCode));
            if (existSubject == null)
            {
                await _context.Subjects.AddAsync(subject);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = new Subject
            {
                Id = id
            };
            _context.Subjects.Attach(subject);
            _context.Subjects.Remove(subject);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<Subject>> GetAllSubjectsAsync()
        {
            return _context.Subjects.ToListAsync();
        }

        public Task<Subject> GetSubjectAsync(int id)
        {
            return _context.Subjects.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateSubjectAsync(Subject subject)
        {
            var newSubject = await _context.Subjects.SingleOrDefaultAsync(x => x.Id == subject.Id);
            if (newSubject != null)
            {
                newSubject.DepartmentId = subject.DepartmentId;
                if (!subject.SubjectCode.Equals(newSubject.SubjectCode))
                {
                    newSubject.PreviousCode = newSubject.SubjectCode;
                    newSubject.SubjectCode = subject.SubjectCode;
                }
                newSubject.Name = subject.Name;
                _context.Subjects.Update(newSubject);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
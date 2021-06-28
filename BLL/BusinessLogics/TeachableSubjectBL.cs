using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class TeachableSubjectBL : ITeachableSubjectBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public TeachableSubjectBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateTeachableSubjectAsync(TeachableSubject teachable)
        {
            var existSubject = await _context
                .TeachableSubjects
                .SingleOrDefaultAsync(x => x.LecturerId == teachable.LecturerId && x.SubjectId == teachable.SubjectId);
            if (existSubject == null)
            {
                await _context.TeachableSubjects.AddAsync(teachable);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteTeachableSubjectAsync(int lecturerId, int subjectId)
        {
            var teachable = new TeachableSubject
            {
                LecturerId = lecturerId,
                SubjectId = subjectId
            };
            _context.TeachableSubjects.Attach(teachable);
            _context.TeachableSubjects.Remove(teachable);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<TeachableSubject> GetTeachableSubjectAsync(int lecturerId, int subjectId)
        {
            return _context.TeachableSubjects.Include(x => x.Lecturer).Include(x => x.Subject).SingleOrDefaultAsync(x => x.LecturerId == lecturerId && x.SubjectId == subjectId);
        }

        public Task<List<TeachableSubject>> GetAllTeachableSubjectsAsync()
        {
            return _context.TeachableSubjects.Include(x => x.Lecturer).Include(x => x.Subject).ToListAsync();
        }

        public async Task<bool> UpdateTeachableSubjectAsync(TeachableSubject teachable)
        {
            var newRegister = await GetTeachableSubjectAsync(teachable.LecturerId, teachable.SubjectId);
            if (newRegister != null)
            {
                newRegister.SubjectId = teachable.SubjectId;
                newRegister.PreferPoint = teachable.PreferPoint;
                newRegister.MatchPoint = teachable.MatchPoint;
                _context.TeachableSubjects.Update(newRegister);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
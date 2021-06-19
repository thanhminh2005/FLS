using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class LecturerTypeBL : ILecturerTypeBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public LecturerTypeBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateLecturerTypeAsync(LecturerType type)
        {
            var existLecturerType = await _context.LecturerTypes.SingleOrDefaultAsync(x => x.Name.Equals(type.Name));
            if (existLecturerType == null)
            {
                await _context.LecturerTypes.AddAsync(type);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteLecturerTypeAsync(int id)
        {
            var type = new LecturerType
            {
                Id = id
            };
            _context.LecturerTypes.Attach(type);
            _context.LecturerTypes.Remove(type);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<LecturerType>> GetAllLecturerTypesAsync()
        {
            return _context.LecturerTypes.ToListAsync();
        }

        public Task<LecturerType> GetLecturerTypeAsync(int id)
        {
            return _context.LecturerTypes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateLecturerTypeAsync(LecturerType type)
        {
            var newLecturerType = await GetLecturerTypeAsync(type.Id);
            if (newLecturerType != null)
            {
                newLecturerType.Name = type.Name;
                _context.LecturerTypes.Update(newLecturerType);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
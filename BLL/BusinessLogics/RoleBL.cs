using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class RoleBL : IRoleBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public RoleBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateRoleAsync(Role role)
        {
            var existRole = await _context.Roles.SingleOrDefaultAsync(x => x.Name.Equals(role.Name));
            if (existRole == null)
            {
                await _context.Roles.AddAsync(role);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = new Role
            {
                Id = id
            };
            _context.Roles.Attach(role);
            _context.Roles.Remove(role);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<Role>> GetAllRolesAsync()
        {
            return _context.Roles.ToListAsync();
        }

        public Task<Role> GetRoleAsync(int id)
        {
            return _context.Roles.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateRoleAsync(Role role)
        {
            var newRole = await GetRoleAsync(role.Id);
            if (newRole != null)
            {
                newRole.Name = role.Name;
                _context.Roles.Update(newRole);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
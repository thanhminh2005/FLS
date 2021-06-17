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
    public class DepartmentBL : IDepartmentBL
    {

        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public DepartmentBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateDepartmentAsync(Department department)
        {
            var existDepartment = await _context.Departments.SingleOrDefaultAsync(x => x.Name.Equals(department.Name));
            if (existDepartment == null)
            {
                await _context.Departments.AddAsync(department);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = new Department
            {
                Id = id
            };
            _context.Departments.Attach(department);
            _context.Departments.Remove(department);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            return _context.Departments.ToListAsync();
        }

        public Task<Department> GetDepartmentAsync(int id)
        {
            return _context.Departments.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            var newDepartment = await _context.Departments.SingleOrDefaultAsync(x => x.Id == department.Id);
            if (newDepartment != null)
            {
                newDepartment.Name = department.Name;
                newDepartment.Description = department.Description;

                _context.Departments.Update(newDepartment);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}

using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class DepartmentBlogBL : IDepartmentBlogBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public DepartmentBlogBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateDepartmentBlogAsync(DepartmentBlog blog)
        {
            await _context.DepartmentBlogs.AddAsync(blog);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteDepartmentBlogAsync(int departmentId, int blogId)
        {
            var blog = new DepartmentBlog
            {
                BlogId = blogId,
                DepartmentId = departmentId
            };
            _context.DepartmentBlogs.Attach(blog);
            _context.DepartmentBlogs.Remove(blog);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<List<DepartmentBlog>> GetAllDepartmentBlogsAsync()
        {
            return _context
                .DepartmentBlogs
                .Include(x => x.Blog)
                .Include(x => x.Department)
                .ToListAsync();
        }

        public Task<DepartmentBlog> GetDepartmentBlogAsync(int departmentId, int blogId)
        {
            return _context
                .DepartmentBlogs
                .Include(x => x.Blog)
                .Include(x => x.Department)
                .SingleOrDefaultAsync(x => x.BlogId == blogId && x.DepartmentId == departmentId);
        }

        public async Task<bool> UpdateDepartmentBlogAsync(DepartmentBlog blog)
        {
            var newDepartmentBlog = await GetDepartmentBlogAsync(blog.DepartmentId, blog.BlogId);
            if (newDepartmentBlog != null)
            {
                newDepartmentBlog.BlogId = blog.BlogId;
                newDepartmentBlog.DepartmentId = blog.DepartmentId;
                _context.DepartmentBlogs.Update(newDepartmentBlog);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
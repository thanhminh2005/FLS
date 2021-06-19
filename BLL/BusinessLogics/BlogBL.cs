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
    public class BlogBL : IBlogBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public BlogBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateBlogAsync(Blog blog)
        {
            blog.PublishDate = DateTime.UtcNow;
            blog.ModifiledDate = DateTime.UtcNow;
            await _context.Blogs.AddAsync(blog);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var blog = new Blog
            {
                Id = id
            };
            _context.Blogs.Attach(blog);
            _context.Blogs.Remove(blog);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<Blog> GetBlogAsync(int id)
        {
            return _context.Blogs.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Blog>> GetAllBlogsAsync()
        {
            return _context.Blogs.ToListAsync();
        }

        public async Task<bool> UpdateBlogAsync(Blog blog)
        {
            var newBlog = await GetBlogAsync(blog.Id);
            if (newBlog != null)
            {
                newBlog.BlogCategoryId = blog.BlogCategoryId;
                newBlog.Description = blog.Description;
                newBlog.ModifiledDate = DateTime.UtcNow;
                newBlog.Title = blog.Title;
                _context.Blogs.Update(newBlog);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
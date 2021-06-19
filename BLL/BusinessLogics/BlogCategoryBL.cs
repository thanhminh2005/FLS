using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class BlogCategoryBL : IBlogCategoryBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public BlogCategoryBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateBlogCategoryAsync(BlogCategory category)
        {
            await _context.BlogCategories.AddAsync(category);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteBlogCategoryAsync(int id)
        {
            var category = new BlogCategory
            {
                Id = id
            };
            _context.BlogCategories.Attach(category);
            _context.BlogCategories.Remove(category);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<BlogCategory> GetBlogCategoryAsync(int id)
        {
            return _context.BlogCategories.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<BlogCategory>> GetAllBlogCategoriesAsync()
        {
            return _context.BlogCategories.ToListAsync();
        }

        public async Task<bool> UpdateBlogCategoryAsync(BlogCategory category)
        {
            var newCategory = await _context.BlogCategories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if (newCategory != null)
            {
                newCategory.Name = category.Name;
                _context.BlogCategories.Update(newCategory);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}
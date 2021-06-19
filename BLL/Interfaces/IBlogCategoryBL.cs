using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlogCategoryBL
    {
        Task<List<BlogCategory>> GetAllBlogCategoriesAsync();

        Task<BlogCategory> GetBlogCategoryAsync(int id);

        Task<bool> UpdateBlogCategoryAsync(BlogCategory category);

        Task<bool> DeleteBlogCategoryAsync(int id);

        Task<bool> CreateBlogCategoryAsync(BlogCategory category);
    }
}
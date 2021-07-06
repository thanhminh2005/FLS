using BLL.Queries;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlogBL
    {
        Task<List<Blog>> GetAllBlogsAsync(GetAllBlogQuery query =  null);

        Task<Blog> GetBlogAsync(int id);

        Task<bool> UpdateBlogAsync(Blog blog);

        Task<bool> DeleteBlogAsync(int id);

        Task<bool> CreateBlogAsync(Blog blog);
    }
}
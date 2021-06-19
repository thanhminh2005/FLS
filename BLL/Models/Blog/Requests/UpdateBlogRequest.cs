using System;

namespace BLL.Models.Blog.Requests
{
    public class UpdateBlogRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ModifiledDate { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
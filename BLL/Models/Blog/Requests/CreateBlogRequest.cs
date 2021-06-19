namespace BLL.Models.Blog.Requests
{
    public class CreateBlogRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
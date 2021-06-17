using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Blog.Responses
{
    public class BlogResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ModifiledDate { get; set; }
        public int BlogCategoryId { get; set; }
    }
}

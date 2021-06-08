using System.Collections.Generic;

#nullable disable

namespace DAL.Enities
{
    public partial class BlogCategory
    {
        public BlogCategory()
        {
            Blogs = new HashSet<Blog>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
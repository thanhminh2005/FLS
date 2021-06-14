using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Blog
    {
        public Blog()
        {
            DepartmentBlogs = new HashSet<DepartmentBlog>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime ModifiledDate { get; set; }
        public int BlogCategoryId { get; set; }
        public string DepartmentId { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }
        public virtual ICollection<DepartmentBlog> DepartmentBlogs { get; set; }
    }
}

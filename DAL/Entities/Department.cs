using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Department
    {
        public Department()
        {
            DepartmentBlogs = new HashSet<DepartmentBlog>();
            Lectures = new HashSet<Lecture>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DepartmentBlog> DepartmentBlogs { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}

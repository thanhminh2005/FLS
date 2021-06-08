using System.Collections.Generic;

#nullable disable

namespace DAL.Enities
{
    public partial class Department
    {
        public Department()
        {
            Blogs = new HashSet<Blog>();
            Lectures = new HashSet<Lecture>();
            Subjects = new HashSet<Subject>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
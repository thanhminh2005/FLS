﻿#nullable disable

namespace DAL.Entities
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
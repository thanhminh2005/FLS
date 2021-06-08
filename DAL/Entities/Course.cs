﻿using System.Collections.Generic;

#nullable disable

namespace DAL.Enities
{
    public partial class Course
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string SubjectId { get; set; }
        public string SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
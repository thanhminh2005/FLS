using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class SemesterPlan
    {
        public SemesterPlan()
        {
            LecturerRatings = new HashSet<LecturerRating>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<LecturerRating> LecturerRatings { get; set; }
    }
}

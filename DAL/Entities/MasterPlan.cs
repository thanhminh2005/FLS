using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class MasterPlan
    {
        public MasterPlan()
        {
            SemesterPlans = new HashSet<SemesterPlan>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SemesterId { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<SemesterPlan> SemesterPlans { get; set; }
    }
}

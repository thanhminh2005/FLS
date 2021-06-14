using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class SemesterPlan
    {
        public SemesterPlan()
        {
            LecturerRatings = new HashSet<LecturerRating>();
            SubjectRegisters = new HashSet<SubjectRegister>();
            TimeSlotRegisters = new HashSet<TimeSlotRegister>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SemesterId { get; set; }
        public int MasterPlanId { get; set; }

        public virtual MasterPlan MasterPlan { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<LecturerRating> LecturerRatings { get; set; }
        public virtual ICollection<SubjectRegister> SubjectRegisters { get; set; }
        public virtual ICollection<TimeSlotRegister> TimeSlotRegisters { get; set; }
    }
}

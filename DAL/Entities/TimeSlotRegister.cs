using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class TimeSlotRegister
    {
        public int PreferPoint { get; set; }
        public int SemesterPlanId { get; set; }
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public int TimeSlotId { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual SemesterPlan SemesterPlan { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            LecturerPlanConstraints = new HashSet<LecturerPlanConstraint>();
            PreferTimeSlots = new HashSet<PreferTimeSlot>();
            Sessions = new HashSet<Session>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int PriorityPoint { get; set; }

        public virtual ICollection<LecturerPlanConstraint> LecturerPlanConstraints { get; set; }
        public virtual ICollection<PreferTimeSlot> PreferTimeSlots { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}

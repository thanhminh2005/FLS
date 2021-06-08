using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Enities
{
    public partial class Session
    {
        public Session()
        {
            Schedules = new HashSet<Schedule>();
        }

        public string Id { get; set; }
        public int SessionNumber { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlotId { get; set; }
        public string CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            TimeSlotRegisters = new HashSet<TimeSlotRegister>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int PriorityPoint { get; set; }

        public virtual ICollection<TimeSlotRegister> TimeSlotRegisters { get; set; }
    }
}
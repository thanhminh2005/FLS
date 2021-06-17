using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.TimeSlot.Requests
{
    public class TimeSlotRequest
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int PriorityPoint { get; set; }
    }
}

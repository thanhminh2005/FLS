using System;

namespace BLL.Models.TimeSlot.Responses
{
    public class TimeSlotResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int PriorityPoint { get; set; }
    }
}
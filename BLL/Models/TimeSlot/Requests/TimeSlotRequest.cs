namespace BLL.Models.TimeSlot.Requests
{
    public class TimeSlotRequest
    {
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PriorityPoint { get; set; }
    }
}
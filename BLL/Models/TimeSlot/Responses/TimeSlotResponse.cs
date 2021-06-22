namespace BLL.Models.TimeSlot.Responses
{
    public class TimeSlotResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PriorityPoint { get; set; }
    }
}
namespace BLL.Models.TimeSlotRegister.Requests
{
    public class CreateTimeSlotRegisterRequest
    {
        public int PreferPoint { get; set; }
        public int SemesterPlanId { get; set; }
        public int LecturerId { get; set; }
        public int TimeSlotId { get; set; }
    }
}
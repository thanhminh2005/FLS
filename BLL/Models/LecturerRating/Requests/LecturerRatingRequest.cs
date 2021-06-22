namespace BLL.Models.LecturerRating.Requests
{
    public class LecturerRatingRequest
    {
        public int LecturerId { get; set; }
        public int SemesterPlanId { get; set; }
        public int RatePoint { get; set; }
    }
}
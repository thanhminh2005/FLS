#nullable disable

namespace DAL.Entities
{
    public partial class LecturerRating
    {
        public int LecturerId { get; set; }
        public int SemesterPlanId { get; set; }
        public int RatePoint { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual SemesterPlan SemesterPlan { get; set; }
    }
}
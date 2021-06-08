#nullable disable

namespace DAL.Enities
{
    public partial class LecturerPlanConstraint
    {
        public string SemesterPlanId { get; set; }
        public string LecturerId { get; set; }
        public string SubjectCode { get; set; }
        public string TimeSlotId { get; set; }
        public string ConstraintTypeId { get; set; }

        public virtual ConstraintType ConstraintType { get; set; }
        public virtual Subject SubjectCodeNavigation { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
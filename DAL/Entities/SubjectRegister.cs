#nullable disable

namespace DAL.Entities
{
    public partial class SubjectRegister
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterPlanId { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual SemesterPlan SemesterPlan { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
#nullable disable

namespace DAL.Entities
{
    public partial class LectureSemesterRegister
    {
        public int LecturerId { get; set; }
        public int SemesterId { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
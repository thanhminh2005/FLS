using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Lecture
    {
        public Lecture()
        {
            LectureSemesterRegisters = new HashSet<LectureSemesterRegister>();
            LecturerRatings = new HashSet<LecturerRating>();
            SubjectRegisters = new HashSet<SubjectRegister>();
            TeachableSubjects = new HashSet<TeachableSubject>();
            TimeSlotRegisters = new HashSet<TimeSlotRegister>();
        }

        public int Id { get; set; }
        public bool Status { get; set; }
        public int MaxCourse { get; set; }
        public int MinCourse { get; set; }
        public int LecturerType { get; set; }
        public int PriorityPoint { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public string LecturerCode { get; set; }

        public virtual Department Department { get; set; }
        public virtual LecturerType LecturerTypeNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
        public virtual ICollection<LectureSemesterRegister> LectureSemesterRegisters { get; set; }
        public virtual ICollection<LecturerRating> LecturerRatings { get; set; }
        public virtual ICollection<SubjectRegister> SubjectRegisters { get; set; }
        public virtual ICollection<TeachableSubject> TeachableSubjects { get; set; }
        public virtual ICollection<TimeSlotRegister> TimeSlotRegisters { get; set; }
    }
}
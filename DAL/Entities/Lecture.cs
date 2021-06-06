using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Lecture
    {
        public Lecture()
        {
            Certificates = new HashSet<Certificate>();
            LectureSemesterRegisters = new HashSet<LectureSemesterRegister>();
            LecturerRatings = new HashSet<LecturerRating>();
            PreferSubjects = new HashSet<PreferSubject>();
            PreferTimeSlots = new HashSet<PreferTimeSlot>();
            Schedules = new HashSet<Schedule>();
            TeachingLevels = new HashSet<TeachingLevel>();
        }

        public string Id { get; set; }
        public bool Status { get; set; }
        public int MaxTime { get; set; }
        public int MinTime { get; set; }
        public string Type { get; set; }
        public int PriorityPoint { get; set; }
        public string DepartmentId { get; set; }
        public string Username { get; set; }

        public virtual Department Department { get; set; }
        public virtual User UsernameNavigation { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<LectureSemesterRegister> LectureSemesterRegisters { get; set; }
        public virtual ICollection<LecturerRating> LecturerRatings { get; set; }
        public virtual ICollection<PreferSubject> PreferSubjects { get; set; }
        public virtual ICollection<PreferTimeSlot> PreferTimeSlots { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TeachingLevel> TeachingLevels { get; set; }
    }
}

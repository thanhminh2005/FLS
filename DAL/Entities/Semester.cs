using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Enities
{
    public partial class Semester
    {
        public Semester()
        {
            Courses = new HashSet<Course>();
            LectureSemesterRegisters = new HashSet<LectureSemesterRegister>();
            SemesterPlans = new HashSet<SemesterPlan>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<LectureSemesterRegister> LectureSemesterRegisters { get; set; }
        public virtual ICollection<SemesterPlan> SemesterPlans { get; set; }
    }
}
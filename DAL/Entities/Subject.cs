using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
            SubjectRegisters = new HashSet<SubjectRegister>();
            TeachableSubjects = new HashSet<TeachableSubject>();
        }

        public string SubjectCode { get; set; }
        public string Name { get; set; }
        public string PreviousCode { get; set; }
        public int DepartmentId { get; set; }
        public int Id { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<SubjectRegister> SubjectRegisters { get; set; }
        public virtual ICollection<TeachableSubject> TeachableSubjects { get; set; }
    }
}
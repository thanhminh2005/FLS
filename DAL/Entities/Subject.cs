using System.Collections.Generic;

#nullable disable

namespace DAL.Enities
{
    public partial class Subject
    {
        public Subject()
        {
            LecturerPlanConstraints = new HashSet<LecturerPlanConstraint>();
            PreferSubjects = new HashSet<PreferSubject>();
        }

        public string SubjectCode { get; set; }
        public string Name { get; set; }
        public string PreviousCode { get; set; }
        public int NumberOfSession { get; set; }
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<LecturerPlanConstraint> LecturerPlanConstraints { get; set; }
        public virtual ICollection<PreferSubject> PreferSubjects { get; set; }
    }
}
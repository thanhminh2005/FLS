using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class ConstraintType
    {
        public ConstraintType()
        {
            LecturerPlanConstraints = new HashSet<LecturerPlanConstraint>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LecturerPlanConstraint> LecturerPlanConstraints { get; set; }
    }
}

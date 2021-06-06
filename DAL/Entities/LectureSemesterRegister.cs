using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class LectureSemesterRegister
    {
        public string LecturerId { get; set; }
        public string SemesterId { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual Semester Semester { get; set; }
    }
}

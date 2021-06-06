using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class PreferSubject
    {
        public string LecturerId { get; set; }
        public string SubjectCode { get; set; }
        public int PreferPoint { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual Subject SubjectCodeNavigation { get; set; }
    }
}

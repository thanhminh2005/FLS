using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Schedule
    {
        public string LecturerId { get; set; }
        public string SessionId { get; set; }
        public bool Attendant { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual Session Session { get; set; }
    }
}

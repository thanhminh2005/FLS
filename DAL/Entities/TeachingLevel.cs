using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class TeachingLevel
    {
        public string LevelId { get; set; }
        public string LecturerId { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual Level Level { get; set; }
    }
}

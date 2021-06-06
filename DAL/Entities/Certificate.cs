using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Certificate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string LecturerId { get; set; }

        public virtual Lecture Lecturer { get; set; }
    }
}

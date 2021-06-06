﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class LecturerRating
    {
        public string LecturerId { get; set; }
        public string SemesterPlanId { get; set; }
        public int RatePoint { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual SemesterPlan SemesterPlan { get; set; }
    }
}
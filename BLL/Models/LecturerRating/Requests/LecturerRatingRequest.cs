using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.LecturerRating.Requests
{
    public class LecturerRatingRequest
    {
        public int LecturerId { get; set; }
        public int SemesterPlanId { get; set; }
        public int RatePoint { get; set; }
    }
}

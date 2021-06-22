using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.TimeSlotRegister.Responses
{
    public class TimeSlotRegisterResponse
    {
        public int PreferPoint { get; set; }
        public int SemesterPlanId { get; set; }
        public int Id { get; set; }
        public int LecturerId { get; set; }
        public int TimeSlotId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.TimeSlotRegister.Requests
{
    public class UpdateTimeSlotRegisterRequest
    {
        public int PreferPoint { get; set; }
        public int SemesterPlanId { get; set; }
        public int TimeSlotId { get; set; }
    }
}

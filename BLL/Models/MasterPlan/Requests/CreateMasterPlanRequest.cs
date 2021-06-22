using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.MasterPlan.Requests
{
    public class CreateMasterPlanRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SemesterId { get; set; }
    }
}

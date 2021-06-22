using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.MasterPlan.Responses
{
    public class MasterPlanResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SemesterId { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Queries
{
    public class GetAllSubjectQuery
    {
        [FromRoute(Name = "departmentId")]
        public int DepartmentId { get; set; }
    }
}

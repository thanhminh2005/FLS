using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Queries
{
    public class GetAllLecturerQuery
    {
        [FromRoute(Name = "departmentId")]
        public int DepartmentId { get; set; }
        [FromRoute(Name = "typeId")]
        public int LecturerTypeId { get; set; }
    }
}

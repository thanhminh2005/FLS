using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Lecturer.Requests
{
    public class LecturerRequest
    {
        public bool Status { get; set; }
        public int MaxCourse { get; set; }
        public int MinCourse { get; set; }
        public int LecturerTypeId { get; set; }
        public int PriorityPoint { get; set; }
        public int DepartmentId { get; set; }
        public int UserId { get; set; }
        public string LecturerCode { get; set; }
    }
}

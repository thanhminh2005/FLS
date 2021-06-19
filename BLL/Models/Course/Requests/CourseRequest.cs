using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Course.Requests
{
    public class CourseRequest
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public int SemesterId { get; set; }
    }
}

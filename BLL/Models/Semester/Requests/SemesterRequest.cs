using System;

namespace BLL.Models.Semester.Requests
{
    public class SemesterRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
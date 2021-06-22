using System;

namespace BLL.Models.Semester.Responses
{
    public class SemesterResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
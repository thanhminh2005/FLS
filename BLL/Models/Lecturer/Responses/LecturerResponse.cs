namespace BLL.Models.Lecturer.Responses
{
    public class LecturerResponse
    {
        public int Id { get; set; }
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
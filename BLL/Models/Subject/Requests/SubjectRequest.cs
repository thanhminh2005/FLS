namespace BLL.Models.Subject.Requests
{
    public class SubjectRequest
    {
        public string SubjectCode { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
namespace BLL.Models.Subject.Responses
{
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string SubjectCode { get; set; }
        public string PreviousCode { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
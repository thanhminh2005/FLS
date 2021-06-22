namespace BLL.Models.SubjectRegister.Requests
{
    public class SubjectRegisterRequest
    {
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }
        public int SemesterPlanId { get; set; }
    }
}
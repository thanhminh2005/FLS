namespace BLL.Models.TeachableSubject.Requests
{
    public class TeachableSubjectRequest
    {
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }
        public int PreferPoint { get; set; }
        public int MatchPoint { get; set; }
    }
}
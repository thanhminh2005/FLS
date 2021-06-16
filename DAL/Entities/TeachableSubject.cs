#nullable disable

namespace DAL.Entities
{
    public partial class TeachableSubject
    {
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }
        public int PreferPoint { get; set; }
        public int MatchPoint { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
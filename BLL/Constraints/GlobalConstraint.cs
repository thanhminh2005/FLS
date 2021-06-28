namespace BLL.Constraints
{
    public class GlobalConstraint
    {
        public int MinCourse { get; set; }
        public int MaxCourse { get; set; }
        public int MaxSlotDistance { get; set; }
        public int MinLecturerCourse { get; set; }
        public int MaxLecturerCourse { get; set; }
        public int MinOccupationRate { get; set; }
        public int MinPercentPermanentLecturer { get; set; }
        public int MaxPercentPermanentLecturer { get; set; }
        public int MinLecturerInSubject { get; set; }
        public int MaxLecturerInSubject { get; set; }
        public int MinPercentCourseTeachByLecturer { get; set; }
        public int MaxPercentCourseTeachByLecturer { get; set; }
        public string StartWorkTime { get; set; }
        public string EndWorkTime { get; set; }
    }
}

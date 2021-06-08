#nullable disable

namespace DAL.Enities
{
    public partial class PreferTimeSlot
    {
        public string LecturerId { get; set; }
        public string TimeSlotId { get; set; }
        public int PreferPoint { get; set; }

        public virtual Lecture Lecturer { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
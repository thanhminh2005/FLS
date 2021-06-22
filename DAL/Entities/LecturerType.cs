using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class LecturerType
    {
        public LecturerType()
        {
            Lectures = new HashSet<Lecturer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lecturer> Lectures { get; set; }
    }
}
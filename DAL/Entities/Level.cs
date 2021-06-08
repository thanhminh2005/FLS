#nullable disable

namespace DAL.Enities
{
    public partial class Level
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual TeachingLevel IdNavigation { get; set; }
    }
}
#nullable disable

namespace DAL.Enities
{
    public partial class UserRole
    {
        public string Username { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}
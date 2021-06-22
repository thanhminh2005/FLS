namespace BLL.Models.User.Requests
{
    public class UpdateUserRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarLink { get; set; }
        public int RoleId { get; set; }
    }
}
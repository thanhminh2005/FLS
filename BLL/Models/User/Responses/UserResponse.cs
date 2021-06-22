using System;

namespace BLL.Models.User.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string CreateBy { get; set; }
        public string AvatarLink { get; set; }
        public int RoleId { get; set; }
    }
}
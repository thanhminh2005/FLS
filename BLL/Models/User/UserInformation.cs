using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.User
{
    public class UserInformation
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public string Fullname { get; set; }
        public string CreateBy { get; set; }
        public string AvatarLink { get; set; }
    }
}

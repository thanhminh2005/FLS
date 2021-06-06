using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class User
    {
        public User()
        {
            Lectures = new HashSet<Lecture>();
            Requests = new HashSet<Request>();
            Roles = new HashSet<Role>();
        }

        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string CreateBy { get; set; }
        public string AvaterLink { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}

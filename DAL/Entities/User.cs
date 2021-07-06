using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Lectures = new HashSet<Lecturer>();
            Departments = new HashSet<Department>();
        }

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

        public virtual Role Role { get; set; }
        public virtual ICollection<Lecturer> Lectures { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
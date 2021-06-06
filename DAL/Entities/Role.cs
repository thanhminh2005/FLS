using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}

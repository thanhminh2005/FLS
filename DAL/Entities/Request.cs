using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Request
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public string RequestTypeId { get; set; }
        public string Username { get; set; }

        public virtual RequestType RequestType { get; set; }
        public virtual User UsernameNavigation { get; set; }
    }
}

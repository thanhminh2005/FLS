using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.User.Responses
{
    public class AfterLoginUserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}

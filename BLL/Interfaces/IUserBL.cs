using BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserBL
    {
        UserProfile Login(string username, string password);
        UserInformation GetInformation(string username);
    }
}

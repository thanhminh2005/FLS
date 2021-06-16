using BLL.Models.User.Responses;

namespace BLL.Interfaces
{
    public interface IGuestBL
    {
        UserProfileResponse Login(string username, string password);
    }
}
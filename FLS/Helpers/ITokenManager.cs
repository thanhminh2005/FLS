using BLL.Models.User.Responses;

namespace FLS.Helpers
{
    public interface ITokenManager
    {
        string CreateAccessToken(UserProfileResponse user);
    }
}
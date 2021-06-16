using BLL.Models.User.Responses;
using FLS.AppSettings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FLS.Helpers
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtSettings _jwtSettings;

        public TokenManager(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string CreateAccessToken(UserProfileResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("user_id", user.Username.ToString()),
                    new Claim("user_role", user.RoleId.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(60),
                Issuer = null,
                Audience = null,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
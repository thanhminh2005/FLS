using BLL.Interfaces;
using BLL.Models.User.Requests;
using FLS.Contracts;
using FLS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FLS.Controllers
{
    public class GuestController : Controller
    {
        private readonly IGuestBL _guestBL;
        private readonly ITokenManager _token;

        public GuestController(IGuestBL guestBL, ITokenManager token)
        {
            _guestBL = guestBL;
            _token = token;
        }
        [HttpPost(ApiRoute.Guests.Login)]
        public IActionResult Login([FromBody] UserAuthenticationRequest authenticationRequest)
        {
            var user = _guestBL.Login(authenticationRequest.Username, authenticationRequest.Password);
            if (user != null)
            {
                var tokenString = _token.CreateAccessToken(user);
                return Ok(tokenString);
            }
            return BadRequest();
        }
    }
}
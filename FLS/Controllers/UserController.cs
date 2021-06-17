using AutoMapper;
using BLL.Interfaces;
using BLL.Models.User.Requests;
using BLL.Models.User.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBL _userBL;
        private readonly IMapper _mapper;

        public UserController(IUserBL userBL, IMapper mapper)
        {
            _userBL = userBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Users.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var user = await _userBL.GetUserAsync(id);
            if (user != null)
            {
                var response = _mapper.Map<UserResponse>(user);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Users.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userBL.GetAllUsersAsync();
            if (users != null)
            {
                var response = _mapper.Map<List<User>, List<UserResponse>>(users);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Users.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);

            var created = await _userBL.CreateUserAsync(user);
            if(created)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Users.Get.Replace("{id}", user.Id.ToString());

                var response = _mapper.Map<CreateUserResponse>(user);

                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.Users.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.Id = id;
            var updated = await _userBL.UpdateUserAsync(user);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Users.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _userBL.DeleteUserAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
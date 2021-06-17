using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Role.Requests;
using BLL.Models.Role.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleBL _roleBL;
        private readonly IMapper _mapper;

        public RoleController(IRoleBL roleBL, IMapper mapper)
        {
            _roleBL = roleBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Roles.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var role = await _roleBL.GetRoleAsync(id);
            if (role != null)
            {
                var response = _mapper.Map<RoleResponse>(role);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Roles.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleBL.GetAllRolesAsync();
            if (roles != null)
            {
                var response = _mapper.Map<List<Role>, List<RoleResponse>>(roles);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Roles.Create)]
        public async Task<IActionResult> Create([FromBody] RoleRequest request)
        {
            var role = _mapper.Map<Role>(request);

            var created = await _roleBL.CreateRoleAsync(role);
            if(created)
            {
                var response = _mapper.Map<RoleResponse>(role);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Roles.Get.Replace("{id}", role.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();

        }

        [HttpPut(ApiRoute.Roles.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RoleRequest request)
        {
            var role = new Role
            {
                Id = id,
                Name = request.Name
            };
            var updated = await _roleBL.UpdateRoleAsync(role);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Roles.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _roleBL.DeleteRoleAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

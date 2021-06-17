using AutoMapper;
using BLL.Interfaces;
using BLL.Models.LecturerType.Requests;
using BLL.Models.LecturerType.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class LecturerTypeController : Controller
    {
        private readonly ILecturerTypeBL _typeBL;
        private readonly IMapper _mapper;

        public LecturerTypeController(ILecturerTypeBL typeBL, IMapper mapper)
        {
            _typeBL = typeBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.LecturerTypes.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var type = await _typeBL.GetLecturerTypeAsync(id);
            if (type != null)
            {
                var response = _mapper.Map<LecturerTypeResponse>(type);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.LecturerTypes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var types = await _typeBL.GetAllLecturerTypesAsync();
            if (types != null)
            {
                var response = _mapper.Map<List<LecturerType>, List<LecturerTypeResponse>>(types);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.LecturerTypes.Create)]
        public async Task<IActionResult> Create([FromBody] LecturerTypeRequest request)
        {
            var type = _mapper.Map<LecturerType>(request);

            var created = await _typeBL.CreateLecturerTypeAsync(type);
            if (created)
            {
                var response = _mapper.Map<LecturerTypeResponse>(type);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.LecturerTypes.Get.Replace("{id}", type.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();

        }

        [HttpPut(ApiRoute.LecturerTypes.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] LecturerTypeRequest request)
        {
            var type = new LecturerType
            {
                Id = id,
                Name = request.Name
            };
            var updated = await _typeBL.UpdateLecturerTypeAsync(type);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.LecturerTypes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _typeBL.DeleteLecturerTypeAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

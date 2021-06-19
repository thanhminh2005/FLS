using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Lecturer.Requests;
using BLL.Models.Lecturer.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ILecturerBL _lecturerBL;
        private readonly IMapper _mapper;

        public LecturerController(ILecturerBL lecturerBL, IMapper mapper)
        {
            _lecturerBL = lecturerBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Lecturers.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var lecturer = await _lecturerBL.GetLecturerAsync(id);
            if (lecturer != null)
            {
                var response = _mapper.Map<LecturerResponse>(lecturer);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Lecturers.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var lecturers = await _lecturerBL.GetAllLecturersAsync();
            if (lecturers != null)
            {
                var response = _mapper.Map<List<Lecturer>, List<LecturerResponse>>(lecturers);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Lecturers.Create)]
        public async Task<IActionResult> Create([FromBody] LecturerRequest request)
        {
            var lecturer = _mapper.Map<Lecturer>(request);

            var created = await _lecturerBL.CreateLecturerAsync(lecturer);
            if (created)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Lecturers.Get.Replace("{id}", lecturer.Id.ToString());

                var response = _mapper.Map<LecturerResponse>(lecturer);

                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.Lecturers.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] LecturerRequest request)
        {
            var lecturer = _mapper.Map<Lecturer>(request);
            lecturer.Id = id;
            var updated = await _lecturerBL.UpdateLecturerAsync(lecturer);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Lecturers.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _lecturerBL.DeleteLecturerAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
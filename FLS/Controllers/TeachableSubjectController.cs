using AutoMapper;
using BLL.Interfaces;
using BLL.Models.TeachableSubject.Requests;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class TeachableSubjectController : Controller
    {
        private readonly ITeachableSubjectBL _TeachableSubjectBL;
        private readonly IMapper _mapper;

        public TeachableSubjectController(ITeachableSubjectBL TeachableSubjectBL, IMapper mapper)
        {
            _TeachableSubjectBL = TeachableSubjectBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.TeachableSubjects.Get)]
        public async Task<IActionResult> Get([FromRoute(Name = "lec-id")] int lecturerId, [FromRoute(Name = "sub-id")] int subjectId)
        {
            var teachable = await _TeachableSubjectBL.GetTeachableSubjectAsync(lecturerId, subjectId);
            if (teachable != null)
            {
                var response = teachable;
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.TeachableSubjects.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var teachable = await _TeachableSubjectBL.GetAllTeachableSubjectsAsync();
            if (teachable != null)
            {
                var response = teachable;
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.TeachableSubjects.Create)]
        public async Task<IActionResult> Create([FromBody] TeachableSubjectRequest request)
        {
            var teachable = _mapper.Map<TeachableSubject>(request);

            var created = await _TeachableSubjectBL.CreateTeachableSubjectAsync(teachable);
            if (created)
            {
                var response = _TeachableSubjectBL.GetTeachableSubjectAsync(teachable.LecturerId, teachable.SubjectId);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.TeachableSubjects.Get.Replace("{lec-id}/{sub-id}", teachable.LecturerId.ToString() + "/" + teachable.SubjectId.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.TeachableSubjects.Update)]
        public async Task<IActionResult> Update([FromBody] TeachableSubjectRequest request)
        {
            var register = _mapper.Map<TeachableSubject>(request);
            var updated = await _TeachableSubjectBL.UpdateTeachableSubjectAsync(register);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.TeachableSubjects.Delete)]
        public async Task<IActionResult> Delete([FromRoute(Name = "lec-id")] int lecturerId, [FromRoute(Name = "sub-id")] int subjectId)
        {
            var deleted = await _TeachableSubjectBL.DeleteTeachableSubjectAsync(lecturerId, subjectId);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
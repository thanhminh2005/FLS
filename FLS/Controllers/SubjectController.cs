using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Subject.Requests;
using BLL.Models.Subject.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectBL _subjectBL;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectBL subjectBL, IMapper mapper)
        {
            _subjectBL = subjectBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Subjects.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var subject = await _subjectBL.GetSubjectAsync(id);
            if (subject != null)
            {
                var response = _mapper.Map<SubjectResponse>(subject);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Subjects.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _subjectBL.GetAllSubjectsAsync();
            if (subjects != null)
            {
                var response = _mapper.Map<List<Subject>, List<SubjectResponse>>(subjects);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Subjects.Create)]
        public async Task<IActionResult> Create([FromBody] SubjectRequest request)
        {
            var subject = _mapper.Map<Subject>(request);

            var created = await _subjectBL.CreateSubjectAsync(subject);
            if (created)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Subjects.Get.Replace("{id}", subject.Id.ToString());

                var response = _mapper.Map<SubjectResponse>(subject);

                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.Subjects.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SubjectRequest request)
        {
            var subject = _mapper.Map<Subject>(request);
            subject.Id = id;
            var updated = await _subjectBL.UpdateSubjectAsync(subject);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Subjects.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _subjectBL.DeleteSubjectAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Semester.Requests;
using BLL.Models.Semester.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class SemesterController : Controller
    {
        private readonly ISemesterBL _semesterBL;
        private readonly IMapper _mapper;

        public SemesterController(ISemesterBL semesterBL, IMapper mapper)
        {
            _semesterBL = semesterBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Semesters.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var semester = await _semesterBL.GetSemesterAsync(id);
            if (semester != null)
            {
                var response = _mapper.Map<SemesterResponse>(semester);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Semesters.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var semesters = await _semesterBL.GetAllSemestersAsync();
            if (semesters != null)
            {
                var response = _mapper.Map<List<Semester>, List<SemesterResponse>>(semesters);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Semesters.Create)]
        public async Task<IActionResult> Create([FromBody] SemesterRequest request)
        {
            var semester = _mapper.Map<Semester>(request);

            var created = await _semesterBL.CreateSemesterAsync(semester);
            if (created)
            {
                var response = _mapper.Map<SemesterResponse>(semester);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Semesters.Get.Replace("{id}", semester.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.Semesters.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SemesterRequest request)
        {
            var semester = _mapper.Map<Semester>(request);
            semester.Id = id;
            var updated = await _semesterBL.UpdateSemesterAsync(semester);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Semesters.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _semesterBL.DeleteSemesterAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
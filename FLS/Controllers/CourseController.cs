using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Course.Requests;
using BLL.Models.Course.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseBL _courseBL;
        private readonly IMapper _mapper;

        public CourseController(ICourseBL courseBL, IMapper mapper)
        {
            _courseBL = courseBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Courses.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var course = await _courseBL.GetCourseAsync(id);
            if (course != null)
            {
                var response = _mapper.Map<CourseResponse>(course);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Courses.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseBL.GetAllCoursesAsync();
            if (courses != null)
            {
                var response = _mapper.Map<List<Course>, List<CourseResponse>>(courses);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Courses.Create)]
        public async Task<IActionResult> Create([FromBody] CourseRequest request)
        {
            var course = _mapper.Map<Course>(request);

            var created = await _courseBL.CreateCourseAsync(course);
            if (created)
            {
                var response = _mapper.Map<CourseResponse>(course);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Courses.Get.Replace("{id}", course.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.Courses.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CourseRequest request)
        {
            var course = _mapper.Map<Course>(request);
            course.Id = id;
            var updated = await _courseBL.UpdateCourseAsync(course);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Courses.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _courseBL.DeleteCourseAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
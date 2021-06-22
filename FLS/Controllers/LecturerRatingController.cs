using AutoMapper;
using BLL.Interfaces;
using BLL.Models.LecturerRating.Requests;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class LecturerRatingController : Controller
    {
        private readonly ILecturerRatingBL _departmentBlogBL;
        private readonly IMapper _mapper;

        public LecturerRatingController(ILecturerRatingBL departmentBlogBL, IMapper mapper)
        {
            _departmentBlogBL = departmentBlogBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.LecturerRatings.Get)]
        public async Task<IActionResult> Get([FromRoute(Name = "semplan-id")] int semesterPlanId, [FromRoute(Name = "lec-id")] int lecturerId)
        {
            var rating = await _departmentBlogBL.GetLecturerRatingAsync(semesterPlanId, lecturerId);
            if (rating != null)
            {
                var response = rating;
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.LecturerRatings.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var rating = await _departmentBlogBL.GetAllLecturerRatingsAsync();
            if (rating != null)
            {
                var response = rating;
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.LecturerRatings.Create)]
        public async Task<IActionResult> Create([FromBody] LecturerRatingRequest request)
        {
            var rating = _mapper.Map<LecturerRating>(request);

            var created = await _departmentBlogBL.CreateLecturerRatingAsync(rating);
            if (created)
            {
                var response = _departmentBlogBL.GetLecturerRatingAsync(rating.SemesterPlanId, rating.LecturerId);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.LecturerRatings.Get.Replace("{semplan-id}/{lec-id}", rating.SemesterPlanId.ToString()+ "/"+ rating.LecturerId.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.LecturerRatings.Update)]
        public async Task<IActionResult> Update([FromBody] LecturerRatingRequest request)
        {
            var rating = _mapper.Map<LecturerRating>(request);
            var updated = await _departmentBlogBL.UpdateLecturerRatingAsync(rating);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.LecturerRatings.Delete)]
        public async Task<IActionResult> Delete([FromRoute(Name = "semplan-id")] int semesterPlanId, [FromRoute(Name = "lec-id")] int lecturerId)
        {
            var deleted = await _departmentBlogBL.DeleteLecturerRatingAsync(semesterPlanId, lecturerId);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
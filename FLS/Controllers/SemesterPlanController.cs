using AutoMapper;
using BLL.Interfaces;
using BLL.Models.SemesterPlan.Requests;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class SemesterPlanController : Controller
    {
        private readonly ISemesterPlanBL _semesterPlanBL;
        private readonly IMapper _mapper;

        public SemesterPlanController(ISemesterPlanBL semesterPlanBL, IMapper mapper)
        {
            _semesterPlanBL = semesterPlanBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.SemesterPlans.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var plan = await _semesterPlanBL.GetSemesterPlanAsync(id);
            if (plan != null)
            {
                var response = plan;
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.SemesterPlans.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var plans = await _semesterPlanBL.GetAllSemesterPlansAsync();
            if (plans != null)
            {
                var response = plans;
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.SemesterPlans.Create)]
        public async Task<IActionResult> Create([FromBody] CreateSemesterPlanRequest request)
        {
            var plan = _mapper.Map<SemesterPlan>(request);

            var created = await _semesterPlanBL.CreateSemesterPlanAsync(plan);
            if (created)
            {
                var response = plan;
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.SemesterPlans.Get.Replace("{id}", plan.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.SemesterPlans.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSemesterPlanRequest request)
        {
            var plan = _mapper.Map<SemesterPlan>(request);
            plan.Id = id;
            var updated = await _semesterPlanBL.UpdateSemesterPlanAsync(plan);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.SemesterPlans.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _semesterPlanBL.DeleteSemesterPlanAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}

using AutoMapper;
using BLL.Interfaces;
using BLL.Models.MasterPlan.Requests;
using BLL.Models.MasterPlan.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class MasterPlanController : Controller
    {
        private readonly IMasterPlanBL _masterPlanBL;
        private readonly IMapper _mapper;

        public MasterPlanController(IMasterPlanBL masterPlanBL, IMapper mapper)
        {
            _masterPlanBL = masterPlanBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.MasterPlans.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var plan = await _masterPlanBL.GetMasterPlanAsync(id);
            if (plan != null)
            {
                var response = _mapper.Map<MasterPlanResponse>(plan);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.MasterPlans.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var plans = await _masterPlanBL.GetAllMasterPlansAsync();
            if (plans != null)
            {
                var response = _mapper.Map<List<MasterPlan>, List<MasterPlanResponse>>(plans);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.MasterPlans.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMasterPlanRequest request)
        {
            var plan = _mapper.Map<MasterPlan>(request);

            var created = await _masterPlanBL.CreateMasterPlanAsync(plan);
            if (created)
            {
                var response = _mapper.Map<MasterPlanResponse>(plan);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.MasterPlans.Get.Replace("{id}", plan.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.MasterPlans.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMasterPlanRequest request)
        {
            var plan = _mapper.Map<MasterPlan>(request);
            plan.Id = id;
            var updated = await _masterPlanBL.UpdateMasterPlanAsync(plan);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.MasterPlans.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _masterPlanBL.DeleteMasterPlanAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
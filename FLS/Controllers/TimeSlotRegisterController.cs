using AutoMapper;
using BLL.Interfaces;
using BLL.Models.TimeSlotRegister.Requests;
using BLL.Models.TimeSlotRegister.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class TimeSlotRegisterController : Controller
    {
        private readonly ITimeSlotRegisterBL _TimeSlotRegisterBL;
        private readonly IMapper _mapper;

        public TimeSlotRegisterController(ITimeSlotRegisterBL TimeSlotRegisterBL, IMapper mapper)
        {
            _TimeSlotRegisterBL = TimeSlotRegisterBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.TimeSlotRegisters.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var TimeSlotRegister = await _TimeSlotRegisterBL.GetTimeSlotRegisterAsync(id);
            if (TimeSlotRegister != null)
            {
                var response = _mapper.Map<TimeSlotRegisterResponse>(TimeSlotRegister);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.TimeSlotRegisters.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var TimeSlotRegisters = await _TimeSlotRegisterBL.GetAllTimeSlotRegistersAsync();
            if (TimeSlotRegisters != null)
            {
                var response = _mapper.Map<List<TimeSlotRegister>, List<TimeSlotRegisterResponse>>(TimeSlotRegisters);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.TimeSlotRegisters.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTimeSlotRegisterRequest request)
        {
            var TimeSlotRegister = _mapper.Map<TimeSlotRegister>(request);

            var created = await _TimeSlotRegisterBL.CreateTimeSlotRegisterAsync(TimeSlotRegister);
            if (created)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.TimeSlotRegisters.Get.Replace("{id}", TimeSlotRegister.Id.ToString());

                var response = _mapper.Map<TimeSlotRegisterResponse>(TimeSlotRegister);

                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.TimeSlotRegisters.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTimeSlotRegisterRequest request)
        {
            var TimeSlotRegister = _mapper.Map<TimeSlotRegister>(request);
            TimeSlotRegister.Id = id;
            var updated = await _TimeSlotRegisterBL.UpdateTimeSlotRegisterAsync(TimeSlotRegister);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.TimeSlotRegisters.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _TimeSlotRegisterBL.DeleteTimeSlotRegisterAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
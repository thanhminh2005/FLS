using AutoMapper;
using BLL.Interfaces;
using BLL.Models.TimeSlot.Requests;
using BLL.Models.TimeSlot.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotBL _slotBL;
        private readonly IMapper _mapper;

        public TimeSlotController(ITimeSlotBL slotBL, IMapper mapper)
        {
            _slotBL = slotBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.TimeSlots.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var slot = await _slotBL.GetTimeSlotAsync(id);
            if (slot != null)
            {
                var response = _mapper.Map<TimeSlotResponse>(slot);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.TimeSlots.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var slots = await _slotBL.GetAllTimeSlotsAsync();
            if (slots != null)
            {
                var response = _mapper.Map<List<TimeSlot>, List<TimeSlotResponse>>(slots);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.TimeSlots.Create)]
        public async Task<IActionResult> Create([FromBody] TimeSlotRequest request)
        {
            var slot = _mapper.Map<TimeSlot>(request);

            var created = await _slotBL.CreateTimeSlotAsync(slot);
            if (created)
            {
                var response = _mapper.Map<TimeSlotResponse>(slot);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.TimeSlots.Get.Replace("{id}", slot.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();

        }

        [HttpPut(ApiRoute.TimeSlots.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TimeSlotRequest request)
        {
            var slot = _mapper.Map<TimeSlot>(request);
            var updated = await _slotBL.UpdateTimeSlotAsync(slot);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.TimeSlots.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _slotBL.DeleteTimeSlotAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

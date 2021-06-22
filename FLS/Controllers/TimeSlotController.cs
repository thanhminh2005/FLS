using AutoMapper;
using BLL.Interfaces;
using BLL.Models.TimeSlot.Requests;
using BLL.Models.TimeSlot.Responses;
using DAL.Entities;
using FLS.Contracts;
using FLS.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotBL _slotBL;
        private readonly IMapper _mapper;
        private readonly ITimeConvert _timeConvert;

        public TimeSlotController(ITimeSlotBL slotBL, IMapper mapper, ITimeConvert timeConvert)
        {
            _slotBL = slotBL;
            _mapper = mapper;
            _timeConvert = timeConvert;
        }

        [HttpGet(ApiRoute.TimeSlots.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var slot = await _slotBL.GetTimeSlotAsync(id);
            if (slot != null)
            {
                var response = new TimeSlotResponse
                {
                    Id = slot.Id,
                    Name = slot.Name,
                    PriorityPoint = slot.PriorityPoint,
                    EndTime = _timeConvert.TimeSpanToString(slot.EndTime),
                    StartTime = _timeConvert.TimeSpanToString(slot.StartTime)
                };
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
                var response = new List<TimeSlotResponse>();
                foreach (TimeSlot slot in slots)
                {
                    var responseSlot = new TimeSlotResponse
                    {
                        Id = slot.Id,
                        Name = slot.Name,
                        PriorityPoint = slot.PriorityPoint,
                        EndTime = _timeConvert.TimeSpanToString(slot.EndTime),
                        StartTime = _timeConvert.TimeSpanToString(slot.StartTime)
                    };
                    response.Add(responseSlot);
                }
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.TimeSlots.Create)]
        public async Task<IActionResult> Create([FromBody] TimeSlotRequest request)
        {
            var slot = new TimeSlot
            {
                Name = request.Name,
                PriorityPoint = request.PriorityPoint,
                EndTime = _timeConvert.StringToTimeSpan(request.EndTime),
                StartTime = _timeConvert.StringToTimeSpan(request.StartTime)
            };

            var created = await _slotBL.CreateTimeSlotAsync(slot);
            if (created)
            {
                var response = new TimeSlotResponse
                {
                    Id = slot.Id,
                    Name = slot.Name,
                    PriorityPoint = slot.PriorityPoint,
                    EndTime = _timeConvert.TimeSpanToString(slot.EndTime),
                    StartTime = _timeConvert.TimeSpanToString(slot.StartTime)
                };
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.TimeSlots.Get.Replace("{id}", slot.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.TimeSlots.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TimeSlotRequest request)
        {
            var slot = new TimeSlot
            {
                Id = id,
                Name = request.Name,
                PriorityPoint = request.PriorityPoint,
                EndTime = _timeConvert.StringToTimeSpan(request.EndTime),
                StartTime = _timeConvert.StringToTimeSpan(request.StartTime)
            };

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
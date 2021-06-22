using AutoMapper;
using BLL.Interfaces;
using BLL.Models.SemesterRegister.Requests;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class SemesterRegisterController : Controller
    {
        private readonly ISemesterRegisterBL _semesterRegisterBL;
        private readonly IMapper _mapper;

        public SemesterRegisterController(ISemesterRegisterBL semesterRegisterBL, IMapper mapper)
        {
            _semesterRegisterBL = semesterRegisterBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.SemesterRegisters.Get)]
        public async Task<IActionResult> Get([FromRoute(Name = "sem-id")] int semesterId, [FromRoute(Name = "lec-id")] int lecturerId)
        {
            var register = await _semesterRegisterBL.GetSemesterRegisterAsync(semesterId, lecturerId);
            if (register != null)
            {
                var response = register;
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.SemesterRegisters.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var register = await _semesterRegisterBL.GetAllSemesterRegistersAsync();
            if (register != null)
            {
                var response = register;
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.SemesterRegisters.Create)]
        public async Task<IActionResult> Create([FromBody] SemesterRegisterRequest request)
        {
            var register = _mapper.Map<LectureSemesterRegister>(request);

            var created = await _semesterRegisterBL.CreateSemesterRegisterAsync(register);
            if (created)
            {
                var response = _semesterRegisterBL.GetSemesterRegisterAsync(register.SemesterId, register.LecturerId);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.SemesterRegisters.Get.Replace("{sem-id}/{lec-id}", register.SemesterId.ToString() + "/" + register.LecturerId.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.SemesterRegisters.Update)]
        public async Task<IActionResult> Update([FromBody] SemesterRegisterRequest request)
        {
            var register = _mapper.Map<LectureSemesterRegister>(request);
            var updated = await _semesterRegisterBL.UpdateSemesterRegisterAsync(register);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.SemesterRegisters.Delete)]
        public async Task<IActionResult> Delete([FromRoute(Name = "sem-id")] int semesterId, [FromRoute(Name = "lec-id")] int lecturerId)
        {
            var deleted = await _semesterRegisterBL.DeleteSemesterRegisterAsync(semesterId, lecturerId);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

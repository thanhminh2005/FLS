using AutoMapper;
using BLL.Interfaces;
using BLL.Models.SubjectRegister.Requests;
using BLL.Models.SubjectRegister.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class SubjectRegisterController : Controller
    {
        private readonly ISubjectRegisterBL _subjectRegisterBL;
        private readonly IMapper _mapper;

        public SubjectRegisterController(ISubjectRegisterBL subjectRegisterBL, IMapper mapper)
        {
            _subjectRegisterBL = subjectRegisterBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.SubjectRegisters.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var subjectRegister = await _subjectRegisterBL.GetSubjectRegisterAsync(id);
            if (subjectRegister != null)
            {
                var response = _mapper.Map<SubjectRegisterResponse>(subjectRegister);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.SubjectRegisters.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var subjectRegisters = await _subjectRegisterBL.GetAllSubjectRegistersAsync();
            if (subjectRegisters != null)
            {
                var response = _mapper.Map<List<SubjectRegister>, List<SubjectRegisterResponse>>(subjectRegisters);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.SubjectRegisters.Create)]
        public async Task<IActionResult> Create([FromBody] SubjectRegisterRequest request)
        {
            var subjectRegister = _mapper.Map<SubjectRegister>(request);

            var created = await _subjectRegisterBL.CreateSubjectRegisterAsync(subjectRegister);
            if (created)
            {
                var response = _mapper.Map<SubjectRegisterResponse>(subjectRegister);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.SubjectRegisters.Get.Replace("{id}", subjectRegister.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.SubjectRegisters.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SubjectRegisterRequest request)
        {
            var subjectRegister = _mapper.Map<SubjectRegister>(request);
            subjectRegister.Id = id;
            var updated = await _subjectRegisterBL.UpdateSubjectRegisterAsync(subjectRegister);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.SubjectRegisters.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _subjectRegisterBL.DeleteSubjectRegisterAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

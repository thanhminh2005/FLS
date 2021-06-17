using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Department.Requests;
using BLL.Models.Department.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentBL _departmentBL;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentBL departmentBL, IMapper mapper)
        {
            _departmentBL = departmentBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Departments.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var department = await _departmentBL.GetDepartmentAsync(id);
            if (department != null)
            {
                var response = _mapper.Map<DepartmentResponse>(department);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Departments.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentBL.GetAllDepartmentsAsync();
            if (departments != null)
            {
                var response = _mapper.Map<List<Department>, List<DepartmentResponse>>(departments);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Departments.Create)]
        public async Task<IActionResult> Create([FromBody] DepartmentRequest request)
        {
            var department = _mapper.Map<Department>(request);

            var created = await _departmentBL.CreateDepartmentAsync(department);
            if (created)
            {
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Departments.Get.Replace("{id}", department.Id.ToString());

                var response = _mapper.Map<DepartmentResponse>(department);

                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.Departments.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] DepartmentRequest request)
        {
            var department = _mapper.Map<Department>(request);
            department.Id = id;
            var updated = await _departmentBL.UpdateDepartmentAsync(department);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Departments.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _departmentBL.DeleteDepartmentAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

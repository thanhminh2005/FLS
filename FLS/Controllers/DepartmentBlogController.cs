using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DepartmentBlog.Requests;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class DepartmentBlogController : Controller
    {
        private readonly IDepartmentBlogBL _departmentBlogBL;
        private readonly IMapper _mapper;

        public DepartmentBlogController(IDepartmentBlogBL departmentBlogBL, IMapper mapper)
        {
            _departmentBlogBL = departmentBlogBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.DepartmentBlogs.Get)]
        public async Task<IActionResult> Get([FromRoute(Name = "dept-id")] int departmentId, [FromRoute(Name = "blog-id")] int blogId)
        {
            var departmentBlog = await _departmentBlogBL.GetDepartmentBlogAsync(departmentId, blogId);
            if (departmentBlog != null)
            {
                var response = departmentBlog;
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.DepartmentBlogs.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var departmentBlogs = await _departmentBlogBL.GetAllDepartmentBlogsAsync();
            if (departmentBlogs != null)
            {
                var response = departmentBlogs;
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.DepartmentBlogs.Create)]
        public async Task<IActionResult> Create([FromBody] DepartmentBlogRequest request)
        {
            var departmentBlog = _mapper.Map<DepartmentBlog>(request);

            var created = await _departmentBlogBL.CreateDepartmentBlogAsync(departmentBlog);
            if (created)
            {
                var response = _departmentBlogBL.GetDepartmentBlogAsync(departmentBlog.DepartmentId, departmentBlog.BlogId);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.DepartmentBlogs.Get.Replace("{dept-id}/{blog-id}", departmentBlog.DepartmentId.ToString() + "/" + departmentBlog.BlogId.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.DepartmentBlogs.Update)]
        public async Task<IActionResult> Update([FromBody] DepartmentBlogRequest request)
        {
            var departmentBlog = _mapper.Map<DepartmentBlog>(request);
            var updated = await _departmentBlogBL.UpdateDepartmentBlogAsync(departmentBlog);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.DepartmentBlogs.Delete)]
        public async Task<IActionResult> Delete([FromRoute(Name = "dept-id")] int departmentId, [FromRoute(Name = "blog-id")] int blogId)
        {
            var deleted = await _departmentBlogBL.DeleteDepartmentBlogAsync(departmentId, blogId);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
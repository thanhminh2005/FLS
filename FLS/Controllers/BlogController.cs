using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Blog.Requests;
using BLL.Models.Blog.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogBL _blogBL;
        private readonly IMapper _mapper;

        public BlogController(IBlogBL blogBL, IMapper mapper)
        {
            _blogBL = blogBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Blogs.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var blog = await _blogBL.GetBlogAsync(id);
            if (blog != null)
            {
                var response = _mapper.Map<BlogResponse>(blog);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.Blogs.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogBL.GetAllBlogsAsync();
            if (blogs != null)
            {
                var response = _mapper.Map<List<Blog>, List<BlogResponse>>(blogs);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.Blogs.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBlogRequest request)
        {
            var blog = _mapper.Map<Blog>(request);

            var created = await _blogBL.CreateBlogAsync(blog);
            if (created)
            {
                var response = _mapper.Map<BlogResponse>(blog);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.Blogs.Get.Replace("{id}", blog.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();
        }

        [HttpPut(ApiRoute.Blogs.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogRequest request)
        {
            var blog = _mapper.Map<Blog>(request);
            blog.Id = id;
            var updated = await _blogBL.UpdateBlogAsync(blog);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.Blogs.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _blogBL.DeleteBlogAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
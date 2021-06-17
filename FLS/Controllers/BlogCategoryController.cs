using AutoMapper;
using BLL.Interfaces;
using BLL.Models.BlogCategory.Requests;
using BLL.Models.BlogCategory.Responses;
using DAL.Entities;
using FLS.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Controllers
{
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryBL _categoryBL;
        private readonly IMapper _mapper;

        public BlogCategoryController(IBlogCategoryBL categoryBL, IMapper mapper)
        {
            _categoryBL = categoryBL;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.BlogCategories.Get)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var category = await _categoryBL.GetBlogCategoryAsync(id);
            if (category != null)
            {
                var response = _mapper.Map<BlogCategoryResponse>(category);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoute.BlogCategories.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var categorys = await _categoryBL.GetAllBlogCategoriesAsync();
            if (categorys != null)
            {
                var response = _mapper.Map<List<BlogCategory>, List<BlogCategoryResponse>>(categorys);
                return Ok(response);
            }
            return NoContent();
        }

        [HttpPost(ApiRoute.BlogCategories.Create)]
        public async Task<IActionResult> Create([FromBody] BlogCategoryRequest request)
        {
            var category = _mapper.Map<BlogCategory>(request);

            var created = await _categoryBL.CreateBlogCategoryAsync(category);
            if (created)
            {
                var response = _mapper.Map<BlogCategoryResponse>(category);
                var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
                var locationUri = baseUrl + "/" + ApiRoute.BlogCategories.Get.Replace("{id}", category.Id.ToString());
                return Created(locationUri, response);
            }
            return BadRequest();

        }

        [HttpPut(ApiRoute.BlogCategories.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BlogCategoryRequest request)
        {
            var category = new BlogCategory
            {
                Id = id,
                Name = request.Name
            };
            var updated = await _categoryBL.UpdateBlogCategoryAsync(category);
            if (updated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete(ApiRoute.BlogCategories.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _categoryBL.DeleteBlogCategoryAsync(id);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

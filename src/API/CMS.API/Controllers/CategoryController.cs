using CMS.Application.Models.DTOs;
using CMS.Application.Models.VMs;
using CMS.Application.Services.Interface;
using CMS.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GetCategoryVM>> GetCategories()
        {
            var categoryList = await _categoryService.GetCategories();

            return categoryList;
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"> Id must be int </param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetCategoryById")]
        [ProducesResponseType(200)]
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            return category;
        }

        /// <summary>
        /// Get Category By Slug
        /// </summary>
        /// <param name="slug"> String Slug </param>
        /// <returns></returns>
        [HttpGet("{slug}", Name = "GetCategoryBySlug")]
        [ProducesResponseType(200)]
        public async Task<Category> GetCategoryBySlug(string slug)
        {
            var category = await _categoryService.GetBySlug(slug);

            return category;
        }

        /// <summary>
        /// Create A Category
        /// </summary>
        /// <param name="model">
        /// Please check category model in scheme
        /// </param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] CreateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetBySlug(model.Slug);
                if (category == null)
                {
                    await _categoryService.Create(model);
                    return Ok();
                }
                ModelState.AddModelError(string.Empty, $"{model.Name} already exists.");
                return BadRequest();
            }
            return BadRequest();
        }
        /// <summary>
        /// Update A Category. Slug Must Be Unique!
        /// </summary>
        /// <param name="model">
        /// Please check category model in scheme
        /// </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] UpdateCategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(model);
                return Ok(model);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
    }
}

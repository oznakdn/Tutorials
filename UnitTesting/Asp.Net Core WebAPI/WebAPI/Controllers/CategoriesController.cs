using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos.CategoryDtos;
using WebAPI.Services.Contracts;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await categoryService.GetCategories();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(string id)
        {
            var result = await categoryService.GetCategory(id);
            return Ok(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> CategoryProducts(string categoryId)
        {
            var result = await categoryService.GetCategoyProducts(categoryId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                await categoryService.AddCategory(model);
                return Created("", model);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                await categoryService.UpdateCategory(model);
                return Ok(model);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await categoryService.DeleteCategory(id);
            return NoContent();
        }

    }
}
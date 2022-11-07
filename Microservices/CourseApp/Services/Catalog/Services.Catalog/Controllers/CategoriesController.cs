using CourseApp.Shared.ControllerBases;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Dtos.CategoryDtos;
using Services.Catalog.Services;

namespace Services.Catalog.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class CategoriesController:CustomBaseController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
        {
            var result =await categoryService.GetAllAsync();
            return CreateActionResultInstance(result);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult>GetByIdAsync(string categoryId)
        {
            var result = await categoryService.GetByIdAsync(categoryId);
            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateDto createDto)
        {
            var result =await categoryService.CreateAsync(createDto);
            return CreateActionResultInstance(result);
        }
    }
}

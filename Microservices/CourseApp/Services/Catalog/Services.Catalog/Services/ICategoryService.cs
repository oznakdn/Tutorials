using CourseApp.Shared.Results;
using Services.Catalog.Dtos.CategoryDtos;

namespace Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string categoryId);
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto createDto);

    }
}

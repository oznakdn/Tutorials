using WebAPI.Dtos.CategoryDtos;

namespace WebAPI.Services.Contracts
{
    public interface ICategoryService
    {
        Task<List<GetCategoriesDto>> GetCategories();
        Task<GetCategoryDto> GetCategory(string categoryId);
        Task<GetCategoyProductsDto> GetCategoyProducts(string categoryId);
        Task<CreateCategoryDto> AddCategory(CreateCategoryDto model);
        Task<UpdateCategoryDto> UpdateCategory(UpdateCategoryDto model);
        Task DeleteCategory(string id);

    }
}
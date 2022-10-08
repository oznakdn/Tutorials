using WebAPI.Dtos.ProductDtos;

namespace WebAPI.Services.Contracts
{
    public interface IProductService
    {
        Task<List<GetProductsDto>> GetProductsWithCategory();
        Task<List<GetProductsDto>> GetProductsByCategoryId(string categoryId);
        Task<GetProductDto> GetProductById(string productId);
        Task<CreateProductDto> AddProduct(CreateProductDto model);
        Task AddProductWithByCategory(CreateProductWithByCategoryDto model);
        Task<UpdateProductDto> UpdateProduct(UpdateProductDto model);
        Task DeleteProduct(string id);

    }
}
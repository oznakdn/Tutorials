using WebAPI.Dtos.ProductDtos;
using WebAPI.Entities;
using WebAPI.Repositories.Contracts;
using WebAPI.Services.Contracts;

namespace WebAPI.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository = null)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }



        public async Task<List<GetProductsDto>> GetProductsByCategoryId(string categoryId)
        {
            var productsByCategoryId = productRepository.GetAllWithInclude(p => p.CategoryId == Guid.Parse(categoryId), p => p.Category)
                                        .Select(p => new GetProductsDto
                                        {
                                            ProductName = p.ProductName,
                                            Price = p.Price,
                                            Stock = p.Stock,
                                            Category = p.Category.CategoryName
                                        }).ToList();
            return await Task.FromResult(productsByCategoryId);

        }

        public async Task<List<GetProductsDto>> GetProductsWithCategory()
        {
            var productsWithCategory = productRepository.GetAllWithInclude(null, p => p.Category)
                .Select(p => new GetProductsDto
                {
                    Id = p.Id.ToString(),
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Stock = p.Stock,
                    Color = p.Color,
                    Category = p.Category.CategoryName,
                    CategoryId = p.CategoryId.ToString()
                }).ToList();

            return await Task.FromResult(productsWithCategory);

        }

        public async Task<GetProductDto> GetProductById(string productId)
        {
            var product = await productRepository.GetByIdAsync(productId, p => p.Category);
            GetProductDto getProductDto = new()
            {
                Id = product.Id.ToString(),
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                Color = product.Color,
                Category = product.Category.CategoryName
            };

            return getProductDto;
        }

        public async Task<CreateProductDto> AddProduct(CreateProductDto model)
        {
            Product product = new()
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Stock = model.Stock,
                Color = model.Color,
                CategoryId = Guid.Parse(model.CategoryId)
            };

            await productRepository.AddAsync(product);
            return model;
        }

        public async Task<UpdateProductDto> UpdateProduct(UpdateProductDto model)
        {
            var product = await productRepository.GetByIdAsync(model.Id);

            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.Stock = model.Stock;
            product.Color = model.Color;
            product.CategoryId = Guid.Parse(model.CategoryId);

            await productRepository.UpdateAsync(product);
            return model;

        }

        public async Task DeleteProduct(string id)
        {
            await productRepository.DeleteById(id);
        }

        public async Task AddProductWithByCategory(CreateProductWithByCategoryDto model)
        {
            var category = await categoryRepository.GetByIdAsync(model.CategoryId);
            Product product = new()
            {
                ProductName = model.ProductName,
                Price = model.Price,
                Stock = model.Stock,
                Color = model.Color,
                CategoryId = category.Id
            };

            await productRepository.AddAsync(product);

        }
    }
}
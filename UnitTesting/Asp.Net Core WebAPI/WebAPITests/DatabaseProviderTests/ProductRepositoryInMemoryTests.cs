using Microsoft.EntityFrameworkCore;

using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repositories.Concretes;
using WebAPI.Repositories.Contracts;

namespace WebAPITests.DatabaseProviderTests
{
    public class ProductRepositoryInMemoryTests : EFCoreInMemoryBase
    {
        private readonly IProductRepository _productRepository;
        public ProductRepositoryInMemoryTests()
        {
            SetContextOption(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("TestDB").Options);
            SeedData();
        }

        [Fact]
        public async Task AddAsync_When_IsValid_ReturnProduct()
        {
            using var context = new AppDbContext(_contextOptions);
            Product newProduct = new()
            {
                ProductName = "Samsung",
                Price = 10000,
                Stock = 100,
                Color = "Black",
                CategoryId = new Guid("49c3c8ac-6553-48bf-b61d-436c363d0346")
            };

            context.Products.Add(newProduct);
            IProductRepository _productRepository = new ProductRepository(context);

            var result = await _productRepository.AddAsync(newProduct);
            Assert.IsType<Product>(result);
            Assert.Equal(newProduct.Id, result.Id);

        }

        [Fact]
        public async Task GetAllAsync_ReturnProducts()
        {
            using var context = new AppDbContext(_contextOptions);
            var products = context.Products.ToList();

            IProductRepository _productRepository = new ProductRepository(context);

            var result = await _productRepository.GetAllAsync();
            Assert.Equal(products.Count, result.Count());

        }
    }
}
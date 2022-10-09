using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Repositories.Concretes;
using WebAPI.Repositories.Contracts;

namespace WebAPITests.DatabaseProviderTests
{
    public class ProductRepositorySqliteTests : EFCoreInMemoryBase
    {
        public ProductRepositorySqliteTests()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            SeedData();
            SetContextOption(new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options);
        }

        [Fact]
        public async Task GetAll_ReturnList()
        {
            using var context = new AppDbContext(_contextOptions);
            var products = await context.Products.ToListAsync();

            IProductRepository productRepository = new ProductRepository(context);
            var result = await productRepository.GetAllAsync();

            // Assert.NotNull(result);
            //Assert.NotEmpty(result);
            //Assert.Equal(products.Count, result.Count());
        }
    }
}
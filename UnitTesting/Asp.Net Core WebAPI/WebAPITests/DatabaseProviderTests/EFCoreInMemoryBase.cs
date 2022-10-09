using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPITests.DatabaseProviderTests
{
    public class EFCoreInMemoryBase
    {

        protected DbContextOptions<AppDbContext> _contextOptions{get; private set;}

        public void SetContextOption(DbContextOptions<AppDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public void SeedData()
        {
            using var context = new AppDbContext(_contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Categories.Add(
                new Category {
                    Id = new Guid("49c3c8ac-6553-48bf-b61d-436c363d0346"), 
                    CategoryName = "Phone"});
            context.Products.Add( 
                new Product {
                            Id =new Guid("e1233e5f-4a55-4afb-b5ee-bb9fd114af5a"), 
                            ProductName = "IPhone", 
                            Price = 30000, 
                            Stock = 100, 
                            CategoryId = new Guid("49c3c8ac-6553-48bf-b61d-436c363d0346")});

            context.SaveChanges();
        }
    }
}
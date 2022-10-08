using Moq;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repositories.Contracts;

namespace WebAPITests
{
    public class ProductRepositoryTests
    {

        private Mock<IProductRepository> _moqRepository;

        private List<Product> _products;
        public ProductRepositoryTests()
        {
            _moqRepository = new Mock<IProductRepository>();
            _products = new List<Product>
            {
                new Product {Id = new Guid("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7"),
                             ProductName = "Samsung",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127"),
                             Price = 10000, Stock=10,
                             Color = "Silver"},
                new Product {Id = new Guid("054ab3c6-5604-4428-9587-852f6d7c8da4"),
                             ProductName = "Apple",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127"),
                             Price = 20000, Stock=20,
                             Color = "Gold"},
                new Product {Id = new Guid("ed44afb2-3a9f-40f6-a3ff-ef76a1232348"),
                             ProductName = "Huawei",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127"),
                             Price = 15000,
                             Stock=30,
                             Color = "Black"},
                new Product {Id = new Guid("5f729da8-d97a-4eb7-bd38-9bbb6a593a9d"),
                             ProductName = "Macbook",
                             CategoryId=new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429"),
                             Price = 15000,
                             Stock=30,
                             Color = "Black"}
            };
        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public void GetAll_When_PredicateIsNull_ReturnAllList(string productId)
        {

            var id = productId.ToString();
            // Arrange
            var product = _products.First();

            _moqRepository.Setup(p => p.GetByIdAsync(id)).ReturnsAsync(product);

            _moqRepository.Verify(p => p.GetByIdAsync(id), Times.Once());

        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public void GetAll_When_PredicateIsNotNull_ReturnGetProductsByCategoryId(string categoryId)
        {

            // Arrange
            var productList = _products.AsQueryable();
            //var productsCount = productList.Count();

            // Act


            // Assert
            //Assert.Equal<int>(3, productsCount);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using WebAPI.Dtos.ProductDtos;
using WebAPI.Entities;
using WebAPI.Services.Contracts;

namespace WebAPITests
{
    public class ProductsControllerTests
    {

        private Mock<IProductService> _mockProductService;
        private ProductsController _productsController;
        private List<GetProductsDto> _productsDto;
        private GetProductDto _productDto;

        public ProductsControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _productsController = new ProductsController(_mockProductService.Object);
            _productsDto = new List<GetProductsDto>
            {
                new GetProductsDto {Id = new Guid("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7").ToString(),
                             ProductName = "Samsung",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127").ToString(),
                             Price = 10000, Stock=10,
                             Color = "Silver"},
                new GetProductsDto {Id = new Guid("054ab3c6-5604-4428-9587-852f6d7c8da4").ToString(),
                             ProductName = "Apple",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127").ToString(),
                             Price = 20000, Stock=20,
                             Color = "Gold"},
                new GetProductsDto {Id = new Guid("ed44afb2-3a9f-40f6-a3ff-ef76a1232348").ToString(),
                             ProductName = "Huawei",
                             CategoryId=new Guid("27dccd70-8dba-4573-bae0-8f33d3322127").ToString(),
                             Price = 15000,
                             Stock=30,
                             Color = "Black"},
                new GetProductsDto {Id = new Guid("5f729da8-d97a-4eb7-bd38-9bbb6a593a9d").ToString(),
                             ProductName = "Macbook",
                             CategoryId=new Guid("dbc6b8d8-d514-460c-9739-ce76eeeb6429").ToString(),
                             Price = 15000,
                             Stock=30,
                             Color = "Black"}
            };
            _productDto = new GetProductDto
            {
                Id = new Guid("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7").ToString(),
                ProductName = "Samsung",
                Price = 10000,
                Stock = 10,
                Color = "Silver",
                Category = "Phone"
            };


        }

        #region GetProducts Action Tests

        [Fact]
        public async Task GetProducts_ReturnNotNull()
        {
            // Arrange
            var products = _productsDto.ToList();

            // Act
            _mockProductService.Setup(p => p.GetProductsWithCategory()).ReturnsAsync(products);
            var result = await _productsController.GetProducts();


            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetProducts_ExecuteActionMethod()
        {
            // Arrange
            var products = _productsDto.ToList();

            // Act
            _mockProductService.Setup(p => p.GetProductsWithCategory()).ReturnsAsync(products);
            var result = await _productsController.GetProducts();


            // Assert
            _mockProductService.Verify(p => p.GetProductsWithCategory(), Times.Once());

        }

        [Fact]
        public async Task GetProducts_ReturnOkObjectResult()
        {
            // Arrange
            var products = _productsDto.ToList();

            // Act
            _mockProductService.Setup(p => p.GetProductsWithCategory()).ReturnsAsync(products);
            var result = await _productsController.GetProducts();

            // Assert
            var resturnResult = Assert.IsType<OkObjectResult>(result); // Is OkObjectResult
            Assert.Equal(200, resturnResult.StatusCode); // Status code is 200

            var returnModel = Assert.IsAssignableFrom<List<GetProductsDto>>(resturnResult.Value);

        }

        [Fact]
        public async Task GetProducts_ReturnGetProductsDto()
        {
            // Arrange
            var products = _productsDto.ToList();

            // Act
            _mockProductService.Setup(p => p.GetProductsWithCategory()).ReturnsAsync(products);
            var result = await _productsController.GetProducts();

            // Assert
            var resturnResult = Assert.IsType<OkObjectResult>(result); // Is OkObjectResult
            var returnModel = Assert.IsAssignableFrom<List<GetProductsDto>>(resturnResult.Value); // return GetProductsDto

        }
        #endregion

        #region GetProduct Action Tests
        [Theory]
        [InlineData("test-id")]
        public async Task GetProduct_When_NotExistProduct_ReturnNotFound(string productId)
        {
            _mockProductService.Setup(p => p.GetProductById(productId));
            var result = await _productsController.GetProduct(productId);

            var returnResult = Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(null)]
        public async Task GetProduct_When_IdIsNull_ReturnBadRequest(string productId)
        {
            _mockProductService.Setup(p => p.GetProductById(productId));
            var result = await _productsController.GetProduct(productId);
            var returnResult = Assert.IsType<BadRequestResult>(result);
        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public async Task GetProduct_When_IdIsNotNull_ReturnOKObjectResult(Guid productId)
        {
            string id = productId.ToString();
            _mockProductService.Setup(p => p.GetProductById(id)).ReturnsAsync(_productDto);

            var result = await _productsController.GetProduct(id);
            var returnResult = Assert.IsType<OkObjectResult>(result);

        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public async Task GetProduct_When_IdIsNotNull_ReturnGetProductDto(Guid productId)
        {
            string id = productId.ToString();
            _mockProductService.Setup(p => p.GetProductById(id)).ReturnsAsync(_productDto);

            var result = await _productsController.GetProduct(id);
            var returnResult = Assert.IsType<OkObjectResult>(result);
            var returnModel = Assert.IsAssignableFrom<GetProductDto>(returnResult.Value);

        }

        [Theory]
        [InlineData("119fab17-ce5b-49b9-ae4c-b2bf11b3f7a7")]
        public async Task GetProduct_When_ExistProduct_ExecuteGetProductByIdMethod(Guid productId)
        {
            string id = productId.ToString();
            _mockProductService.Setup(p => p.GetProductById(id)).ReturnsAsync(_productDto);

            var result = await _productsController.GetProduct(id);
            _mockProductService.Verify(p => p.GetProductById(id), Times.Once());

        }

        [Theory]
        [InlineData(null)]
        public async Task GetProduct_When_IdIsNull_Not_ExecuteGetProductByIdMethod(string productId)
        {
            _mockProductService.Setup(p => p.GetProductById(productId));
            var result = await _productsController.GetProduct(productId);
            _mockProductService.Verify(p => p.GetProductById(productId), Times.Never());
        }
        #endregion

        #region GetProductsByCategory Action Tests
        [Theory]
        [InlineData(null)]
        public async Task GetProductsByCategory_When_CategoryIdIsNull_ReturnBadRequest(string categoryId)
        {

            var result = await _productsController.GetProductsByCategory(categoryId);
            var returnResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, returnResult.StatusCode);
        }

        [Theory]
        [InlineData("27dccd70-8dba-4573-bae0-8f33d3322127")]
        public async Task GetProductsByCategory_When_CategoryIdIsNotNull_Should_Be_Execute_GetProductsByCategoryMethod(string categoryId)
        {
            //  string CategoryId = categoryId.ToString();
            //  _mockProductService.Setup(p=>p.GetProductsByCategoryId(CategoryId));
            var result = await _productsController.GetProductsByCategory(categoryId);
            _mockProductService.Verify(p => p.GetProductsByCategoryId(categoryId), Times.Once());

        }

        [Theory]
        [InlineData("27dccd70-8dba-4573-bae0-8f33d3322127")]
        public async Task GetProductsByCategory_When_ExistProduct_Should_Be_Execute_GetProductsByCategoryMethod(string categoryId)
        {
            // Arrange
            string CategoryId = categoryId.ToString();
            var existProduct = _productsDto.Where(p => p.CategoryId == CategoryId).ToList();

            // Act
            _mockProductService.Setup(p => p.GetProductsByCategoryId(CategoryId)).ReturnsAsync(existProduct);
            var result = await _productsController.GetProductsByCategory(categoryId);

            // Assert
            _mockProductService.Verify(p => p.GetProductsByCategoryId(categoryId), Times.Once());

        }

        
        #endregion

    }
}
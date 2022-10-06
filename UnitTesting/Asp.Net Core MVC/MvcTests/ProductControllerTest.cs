using Microsoft.AspNetCore.Mvc;
using Moq;
using MvcApp.Controllers;
using MvcApp.Entity;
using MvcApp.Repository.Contacts;

namespace MvcTests
{
    public class ProductControllerTest
    {

        private readonly Mock<IProductRepository> _mock;
        private readonly ProductController _controller;
        private List<Product> _products;

        public ProductControllerTest()
        {
            _mock = new Mock<IProductRepository>();
            _controller = new ProductController(_mock.Object);
            _products = new List<Product>
            {
                new Product {Id=1, ProductName ="Kalem", Price=10, Stock = 100, Color="Black"},
                new Product {Id=2, ProductName ="Silgi", Price=20, Stock = 200, Color="Red"},
                new Product {Id=3, ProductName ="Defter", Price=30, Stock = 300, Color="Orange"}
            };


        }

        #region Index
        [Fact]
        public async void Index_ActionExecutes_ReturnView()
        {

            // Arrange - Act
            var result = await _controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Index_ActionExecute_ReturnProductList()
        {

            // Act
            _mock.Setup(p => p.GetAllAsync()).ReturnsAsync(_products);
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result); // geri donus tipi ViewResult mi?
            var productList = Assert.IsAssignableFrom<IEnumerable<Product>>(viewResult.Model); // geriye IEnumerable tipinde product listesi donuyor mu?
            Assert.Equal<int>(3, productList.Count()); // Listede 3 adet eleman mi var?
        }


        #endregion

        #region Details
        [Theory]
        [InlineData(1)]
        public async void Details_When_ExistId_ReturnProduct(int productId)
        {

            // Arrange
            var existProduct = _products.First(p => p.Id == productId); // Beklenen product nesnesi

            // Act
            _mock.Setup(p => p.GetByIdAsync(productId)).ReturnsAsync(existProduct);
            var result = await _controller.Details(productId);

            // Assert
            var isViewResult = Assert.IsType<ViewResult>(result);

            var resultProductDetail = Assert.IsAssignableFrom<Product>(isViewResult.Model); // Gelen product nesnesi

            Assert.Equal<int>(existProduct.Id, resultProductDetail.Id);
            Assert.Equal<string>(existProduct.ProductName, resultProductDetail.ProductName);

        }

        [Fact]
        public async void Details_When_IdIsNull_ReturnNotFound()
        {

            // Arrange
            Product product = null;

            // Act
            _mock.Setup(p => p.GetByIdAsync(0)).ReturnsAsync(product);
            var result = await _controller.Details(0);

            // Assert
            var isNotFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal<int>(404, isNotFoundResult.StatusCode);


        }
        #endregion

        #region Create
        [Fact]
        public void CreateGet_ActionExecutes_ReturnViewResult()
        {
            // Act
            var result = _controller.Create();
            // Assert
            var isViewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void CreatePost_When_ModelStateInValid_ReturnView()
        {
            // Arrange
            _controller.ModelState.AddModelError("ProductName", "Product Name is required"); // (!ModelState.IsValid) durumunu test ettik
            var result = await _controller.Create(_products.First());

            // Act
            var viewResult = Assert.IsType<ViewResult>(result); // return View() durumunu test ettik
            Assert.IsType<Product>(viewResult.Model); // View(product) durmunu test ettik

        }

        [Fact]
        public async void CreatePost_When_ModelStateValid_ReturnRedirectToAction()
        {

            var result = await _controller.Create(_products.First());
            var redirectoToAction = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectoToAction.ActionName);

        }

        [Fact]
        public async void CreatePost_When_ModelStateValid_CreateMethodExecute()
        {
            // Arrange
            Product newProduct = new Product();

            // Act
            _mock.Setup(p => p.CreateAsync(It.IsIn<Product>())).Callback<Product>(x => newProduct = x);
            var result = await _controller.Create(_products.First());

            // Assert
            _mock.Verify(p => p.CreateAsync(It.IsAny<Product>()), Times.Once()); // CreateAsync metodu bir defa calisiyor mu?

        }

        [Fact]
        public async void CreatePost_When_ModelStateInValid_CreateMethodNotExecute()
        {
            // Arrange
            _controller.ModelState.AddModelError("ProductName", "Product name is required");

            // Act
            var result = await _controller.Create(_products.First());

            // Assert
            _mock.Verify(p => p.CreateAsync(It.IsAny<Product>()), Times.Never()); // CreateAsync metodu calismiyor mu?

        }
        #endregion

        #region Edit

        [Theory]
        [InlineData(4)]
        public async void EditGet_When_NotExistProduct_ReturnNotFound(int productId)
        {
            var existProduct = _products.Find(p => p.Id == productId);

            _mock.Setup(p => p.GetByIdAsync(productId)).ReturnsAsync(existProduct);

            var result = await _controller.Edit(productId);

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Theory]
        [InlineData(2)]
        public async void EditGet_When_ExistProduct_ReturnView(int productId)
        {
            var existProduct = _products.Find(p => p.Id == productId);
            _mock.Setup(p => p.GetByIdAsync(productId)).ReturnsAsync(existProduct);

            var result = await _controller.Edit(productId);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<Product>(viewResult.Model); // View(product) durmunu test ettik

        }

        [Fact]
        public void EditPost_When_ModelStateInValid_ReturnView()
        {
            _controller.ModelState.AddModelError("", "");

            var result = _controller.Edit(_products.First());
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<Product>(viewResult.Model);
        }

        [Fact]
        public void EditPost_When_ModelStateValid_ReturnRedirectToAction()
        {
            var result = _controller.Edit(_products.First());
            var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
            var viewModel = Assert.IsAssignableFrom<Product>(_products.First());
            Assert.Equal("Details", redirectoToActionResult.ActionName);

        }

        [Theory]
        [InlineData(2)]
        public void EditPost_When_ModelStateValid_ReturnRedirectActionWithParameter(int productId)
        {
            var product = _products.Single(p => p.Id == productId);

            _mock.Setup(p => p.Update(product));

            var result = _controller.Edit(product);
            var isRedirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", isRedirectToActionResult.ActionName);

            var redirectToActionParameter = Assert.IsType<int>(isRedirectToActionResult.RouteValues.Values.Single());
            Assert.Equal(productId, redirectToActionParameter);
            Assert.Equal<int>(productId, redirectToActionParameter);

        }


        [Fact]
        public void EditPost_When_ModelStateValid_MethodExecutes()
        {
            Product newProduct = new();

            _mock.Setup(p => p.Update(It.IsAny<Product>())).Callback<Product>(p => newProduct = p);
            var result = _controller.Edit(newProduct);

            _mock.Verify(x => x.Update(newProduct), Times.Once());
        }

        [Fact]
        public void EditPost_When_ModelStateInValid_MethodNotExecutes()
        {
            _controller.ModelState.AddModelError("", "");

            var result = _controller.Edit(_products.First());

            _mock.Verify(x => x.Update(_products.First()), Times.Never());
        }



        #endregion

        #region Delete

        [Theory]
        [InlineData(4)]
        public async void Delete_When_NotExistProduct_ReturnNotFound(int productId)
        {
            var existProduct = _products.Find(p => p.Id == productId);
            _mock.Setup(p => p.GetByIdAsync(productId)).ReturnsAsync(existProduct);

            var result = await _controller.Delete(productId);
            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(2)]
        public async void Delete_When_ExistProduct_ReturnRedirectToActionIndex(int productId)
        {
            var existProduct = _products.Find(p => p.Id == productId);
            _mock.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(existProduct);

            var result = await _controller.Delete(productId);
            var isRedirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", isRedirectToActionResult.ActionName);
        }

        [Theory]
        [InlineData(2)]
        public async void Delete_When_ExistProduct_DeleteMethodExecute(int productId)
        {

            // Controller Delete metodundaki GetByIdAsync metodu icin
            var existProduct = _products.Find(p => p.Id == productId);
            _mock.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(existProduct);

            // Controller Delete metodu
            var result = await _controller.Delete(productId);

            _mock.Verify(p => p.Delete(It.IsAny<Product>()), Times.Once());
        }

        [Theory]
        [InlineData(5)]
        public async void Delete_When_NotExistProduct_DeleteMethodNotExecute(int productId)
        {
            var existProduct = _products.Find(p => p.Id == productId);
            _mock.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(existProduct);
            var result = await _controller.Delete(productId);

            _mock.Verify(p => p.Delete(existProduct), Times.Never());
        }

        [Theory]
        [InlineData(2)]
        public async void Delete_When_ExistProduct_RepositoryDeleteMethodExecuted(int productId)
        {
            var existProduct = _products.Single(p => p.Id == productId);

            // Delete controller da calisan GetById metoduyla nesne bulunuyor
            _mock.Setup(p => p.GetByIdAsync(productId)).ReturnsAsync(existProduct);

            // Bulunan nesne repository'deki delete metoduna gonderiliyor.
            _mock.Setup(p => p.Delete(existProduct));

            // Controller daki delete metodu calistiriliyor
            var result = await _controller.Delete(existProduct.Id);

            // Sonuc 
            _mock.Verify(p => p.Delete(existProduct), Times.Once());

        }

        #endregion
    }
}
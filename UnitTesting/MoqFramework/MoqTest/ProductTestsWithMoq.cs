using Moq;
using MoqApp;
using MoqApp.Abstracts;

namespace MoqTest
{
    public class ProductTestsWithMoq
    {
        private Mock<IProductService> _mock;
        private ProductMethod _productMethod;
        public ProductTestsWithMoq()
        {
            _mock = new Mock<IProductService>();
            _productMethod = new ProductMethod(_mock.Object);
        }




        [Theory]
        [InlineData("Phone", "Notebook", "Mouse", "Keyboard")]
        public void GetProducts_shouldBe_returnTheSameList(string phone, string notebook, string mouse, string keyboard)
        {

            // Arrange
            var products = new List<string> { phone, notebook, mouse, keyboard };
            var expectedResult = products;

            // Act
            _mock.Setup(p => p.GetProducts()).Returns(expectedResult);
            var actualResult = _productMethod.GetAll();

            // Assert
            Assert.Equal<List<string>>(expectedResult, actualResult);

        }


        #region Verify
        [Fact]
        public void ProductsCount_ShouldBe_returnCount()
        {
            // Arrange
            int expectedResult = 4;

            // Act
            _mock.Setup(p => p.ProductsCount()).Returns(expectedResult);
            int actualResult = _productMethod.GetCount();

            // Assert
            Assert.Equal<int>(expectedResult, actualResult);

            // Verify
            _mock.Verify(p => p.ProductsCount(), Times.Once()); // Method bir kere calistigi icin test basarili
            _mock.Verify(p => p.ProductsCount(), Times.Never()); // Metod calistigi icin test basarisiz

        }
        #endregion

        #region Throw

        [Fact]
        public void GetProductsType__ThrowException_returnException()
        {
           
            // Throw
            _mock.Setup(p => p.GetProductsType()).Throws(new Exception("This is IEnumerable"));
            Exception exception =  Assert.Throws<Exception>(()=>_productMethod.GetProductsType());
            Assert.Equal("This is IEnumerable",exception.Message);

        }

        #endregion

    
    }
}
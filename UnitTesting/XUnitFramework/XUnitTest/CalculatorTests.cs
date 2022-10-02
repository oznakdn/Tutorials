using XUnitApp;

namespace XUnitTest
{
    public class CalculatorTests
    {
        [Fact]
        public void Sum_Should_Be_Equal_Ten()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Sum(5, 5);

            // Assert
            Assert.Equal<int>(10, result);
        }
    }
}
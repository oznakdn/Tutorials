using XUnitApp;

namespace XUnitTest
{
    public class XUnitTestMethodNames
    {
        private Method method;
        public XUnitTestMethodNames()
        {
            this.method = new Method();
        }


        [Theory]
        [InlineData(2, 5)]
        public void Sum_PositiveValues_returnPositiveTotalValue(int a, int b)
        {
            var totalValue = method.Sum(a, b);
            var expectedValue = a + b;

            Assert.Equal(expectedValue, totalValue);
        }

        [Theory]
        [InlineData(-2, -5)]
        public void Sum_negativeValues_returnNegativeTotalValue(int a, int b)
        {
            var totalValue = method.Sum(a, b);
            var expectedValue = a + b;

            Assert.Equal(expectedValue, totalValue);
        }

        [Fact]
        public void GetAnimals_ifIsNullParameter_shouldBe_returnNull()
        {
            // Arrange
            var animals = new List<string>();
            animals = null;

            // Act
            var result = method.GetAnimals(animals);

            // Assert
            Assert.Null(result);
        }
    }
}
using XUnitApp;

namespace XUnitTest
{
    public class XUnitTestMethodWithParameter
    {

        // With paramter test methods

        [Theory]
        [InlineData(10, 20)]
        public void IsEqualTest(int a, int b)
        {
            // Arrange
            var method = new Method();

            // Act
            var result = method.Sum(a, b);

            //Assert
            Assert.Equal(result, 30);
        }


        [Theory]
        [InlineData(10, 20)]
        [InlineData(3, 5)]

        public void IsEqualTest2(int a, int b)
        {
            // Arrange
            var method = new Method();

            // Act
            var result = method.Sum(a, b);
            var expectedResult = a + b;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
using XUnitApp;

namespace XUnitTest
{
    public class XUnitTestClassUsingConstructor
    {
        private Method _method;
        public XUnitTestClassUsingConstructor()
        {
            _method = new Method();
        }

        [Fact]
        public void SumTest()
        {
            var result = _method.Sum(10, 20);
            Assert.Equal<int>(result, 30);
        }
    }
}
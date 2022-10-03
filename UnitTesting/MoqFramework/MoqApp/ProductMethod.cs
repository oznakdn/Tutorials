using MoqApp.Abstracts;
using MoqApp.Concretes;

namespace MoqApp
{
    public class ProductMethod
    {
        private readonly IProductService _productService;
        public ProductMethod(IProductService productService)
        {
            _productService = productService;
        }

        public List<string> GetAll()
        {
            return _productService.GetProducts();
        }

        public int GetCount()
        {
            var count = _productService.ProductsCount();
            if (count == 0)
            {
                //throw new Exception("Count is zero");
                return count;
            }
            return count;
        }

        public bool GetProductsType()
        {
            _productService.GetProductsType();
            return true;
        }
    }
}
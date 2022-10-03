using MoqApp.Abstracts;

namespace MoqApp.Concretes
{
    public class ProductService : IProductService
    {
        public List<string> GetProducts()
        {
            return new List<string>() { "Phone", "Notebook", "Mouse", "Keyboard" };
        }

        public bool GetProductsType()
        {
            var productsType = GetProducts().GetType();
            if (productsType is IEnumerable<string>)
            {
                throw new Exception("This is IEnumerable");
            }
            return true;
        }

        public int ProductsCount()
        {
            var products = GetProducts();
            return products.Count;
        }


    }
}
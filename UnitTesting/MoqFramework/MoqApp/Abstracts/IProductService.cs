namespace MoqApp.Abstracts
{
    public interface IProductService
    {
        List<string> GetProducts();
        int ProductsCount();
        bool GetProductsType();
    }
}
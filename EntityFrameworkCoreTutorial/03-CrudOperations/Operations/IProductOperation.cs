
namespace _03_CrudOperations.Operations
{
    using System.Linq.Expressions;
    using _03_CrudOperations.Entities;

    public interface IProductOperation
    {
        void Add(Product product);
        void AddRange(List<Product> products);

        void Update(Product product);
        void UpdateRange(List<Product> products);

        void Delete(Product product);
        public void DeleteRange(List<Product> products, params int[] productsId);
        void RemoveRange(List<Product> products);


        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);


        List<Product> GetAll();
        Product Get(int id);
    }
}
namespace _03_CrudOperations.Operations
{
    using System.Linq.Expressions;
    using _03_CrudOperations.Data;
    using _03_CrudOperations.Entities;
    using Microsoft.EntityFrameworkCore;


    public class ProductOperation : IProductOperation
    {
        protected readonly NorthwindContext _context;

        public ProductOperation(NorthwindContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Entry(product).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void AddRange(List<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {

            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
        }

         public void DeleteRange(List<Product> products, params int[] productsId)
        {
            Product product;
             foreach (var item in productsId)
             {
                product = _context.Products.Where(p => p.ProductId == item).SingleOrDefault();
               _context.Remove(product);
            }
            _context.SaveChanges();
        }

        public void RemoveRange(List<Product> products)
        {
            foreach (var product in products)
            {
                _context.Products.Remove(product);
            }
           _context.SaveChanges();
        }



        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateRange(List<Product> products)
        {
            foreach (Product product in products)
            {
                _context.Entry(product).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }



        public Product Get(int id)
        {
            return _context.Products.SingleOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

       
    }
}
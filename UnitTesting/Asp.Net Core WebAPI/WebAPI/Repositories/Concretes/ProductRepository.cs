using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Concretes
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
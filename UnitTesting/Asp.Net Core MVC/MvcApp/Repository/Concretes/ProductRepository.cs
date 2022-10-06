using MvcApp.Data;
using MvcApp.Entity;
using MvcApp.Repository.Contacts;

namespace MvcApp.Repository.Concretes
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

    }
}
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repositories.Contracts;

namespace WebAPI.Repositories.Concretes
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
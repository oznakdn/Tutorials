using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Repositories.Contracts;


namespace WebAPI.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {

        protected readonly AppDbContext context;


        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;

        }

        public async Task DeleteAsync(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var entity = await context.Set<T>().SingleAsync(e => e.Id == Guid.Parse(id));
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate is null ? context.Set<T>().AsQueryable()
                                      : context.Set<T>().Where(predicate).AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate is null ? await context.Set<T>().ToListAsync()
                                      : await context.Set<T>().Where(predicate).ToListAsync();
        }

        public IEnumerable<T> GetAllWithInclude(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();

            if (predicate is not null) query = query.Where(predicate);

            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).SingleAsync();
        }

        public async Task<T> GetByIdAsync(string id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>();
            query = query.Where(e => e.Id == Guid.Parse(id));
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return await query.FirstAsync();
        }


    }
}
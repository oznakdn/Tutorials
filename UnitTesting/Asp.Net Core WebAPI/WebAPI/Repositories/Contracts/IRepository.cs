using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Repositories.Contracts
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        IEnumerable<T> GetAllWithInclude(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(string id, params Expression<Func<T, object>>[] includes);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteById(string id);

    }
}
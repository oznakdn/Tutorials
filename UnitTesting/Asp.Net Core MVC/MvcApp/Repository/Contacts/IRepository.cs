namespace MvcApp.Repository.Contacts
{
    public interface IRepository<T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
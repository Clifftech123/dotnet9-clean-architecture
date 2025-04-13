namespace Todo.Infrastructure.Interface
{
    public interface IBaseRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> SearchTodoAsync(string searchTerm);

    }
}

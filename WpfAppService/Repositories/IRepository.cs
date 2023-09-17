namespace WpfAppService.Repositories;

public interface IRepository<T>
{
    ValueTask<IEnumerable<T>> GetAllAsync();
    ValueTask<T> GetByAsync(Func<T, bool> predicate);
    ValueTask AddAsync(T entity);
    ValueTask UpdateAsync(T entity);
    ValueTask DeleteAsync();
    ValueTask<bool> ExistsAsync(Func<T, bool> predicate);
}
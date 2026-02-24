namespace BookAuthors.Domain.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetWithPaginationAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken = default);
    Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);

}

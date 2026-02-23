using BookAuthors.Domain.Entities;

namespace BookAuthors.Domain.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetWithPaginationAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(Guid id, T newBook, CancellationToken cancellationToken = default);
}

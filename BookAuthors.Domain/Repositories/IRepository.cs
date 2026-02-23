using BookAuthors.Domain.Entities;

namespace BookAuthors.Domain.Repositories;

public interface IRepository<T>
{
    Task<List<T>> GetWithPaginationAsync(int page, int pageSize);
    Task<T?> GetAsync(Guid id);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(Guid id, T newBook);
}

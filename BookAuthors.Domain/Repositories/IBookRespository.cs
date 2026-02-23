using BookAuthors.Domain.Entities;

namespace BookAuthors.Domain.Repositories;

public interface IBookRespository : IRepository<Book>
{
    Task<List<Book>> GetWithPaginationAsync(int page, int pageSize, Guid? authorId = null, CancellationToken cancellationToken = default);
}

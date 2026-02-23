using BookAuthors.Domain.Entities;

namespace BookAuthors.Domain.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author> InsertAsync(Author author, CancellationToken cancellationToken = default); 
}

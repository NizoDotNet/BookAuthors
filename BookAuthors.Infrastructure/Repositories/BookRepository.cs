using BookAuthors.Domain.Entities;
using BookAuthors.Domain.Repositories;
using BookAuthors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookAuthors.Infrastructure.Repositories;

internal class BookRepository : IBookRespository
{
    private readonly DatabaseContext _db;

    public BookRepository(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<Book?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _db.Books
            .Include(c => c.Authors)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Book>> GetWithPaginationAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _db.Books
           .Include(c => c.Authors)
           .Skip((page - 1) * pageSize)
           .Take(pageSize)
           .ToListAsync();
    }

    public async Task<Book> InsertAsync(Book entity, CancellationToken cancellationToken = default)
    {
        await _db.Books.AddAsync(entity);
        return entity;
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _db.Books
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task UpdateAsync(Guid id, Book newBook, CancellationToken cancellationToken = default)
    {
        await _db.Books
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(c =>
            {
                c.SetProperty(c => c.Title, c => newBook.Title);

            });
    }
}

using BookAuthors.Domain.Entities;
using BookAuthors.Domain.Repositories;
using BookAuthors.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookAuthors.Infrastructure.Repositories;

internal class AuthorRepository : IAuthorRepository
{
    private readonly DatabaseContext _db;

    public AuthorRepository(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<Author?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _db.Authors
            .Include(c => c.Books)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<List<Author>> GetWithPaginationAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _db.Authors
            .Include(c => c.Books)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Author> InsertAsync(Author entity, CancellationToken cancellationToken = default)
    {
        await _db.Authors.AddAsync(entity);
        return entity;
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _db.Authors
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task UpdateAsync(Guid id, Author entity, CancellationToken cancellationToken = default)
    {
        await _db.Authors
           .Where(c => c.Id == id)
           .ExecuteUpdateAsync(c =>
           {
               c.SetProperty(c => c.Name, c => entity.Name);
               c.SetProperty(c => c.Surname, c => entity.Surname);
               c.SetProperty(c => c.Middlename, c => entity.Middlename);
               c.SetProperty(c => c.Bio, c => entity.Bio);

           });
    }
}

using BookAuthors.Application.Interfaces;

namespace BookAuthors.Infrastructure.Persistence;

internal class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _db;

    public UnitOfWork(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await _db.SaveChangesAsync();
    }
}

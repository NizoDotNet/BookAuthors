namespace BookAuthors.Application.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}

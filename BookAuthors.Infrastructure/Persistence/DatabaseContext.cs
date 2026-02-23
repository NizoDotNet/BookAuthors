using BookAuthors.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAuthors.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    protected DatabaseContext(DbContextOptions op)
        : base(op)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}

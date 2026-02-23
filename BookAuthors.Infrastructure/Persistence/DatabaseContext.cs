using BookAuthors.Domain.Entities;
using BookAuthors.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookAuthors.Infrastructure.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());

    }
}

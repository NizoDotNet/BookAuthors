using BookAuthors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookAuthors.Infrastructure.Persistence.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(20);

        builder.Property(c => c.Surname)
            .HasMaxLength(20);

        builder.Property(c => c.Middlename)
            .HasMaxLength(30);

        builder.HasMany(c => c.Books)
            .WithMany(c => c.Authors);
    }
}

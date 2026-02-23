using BookAuthors.Application.Interfaces;
using BookAuthors.Domain.Repositories;
using BookAuthors.Infrastructure.Persistence;
using BookAuthors.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookAuthors.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public void AddPersistence(IConfiguration configuration)
        {
            services.AddScoped<IBookRespository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<DatabaseContext>(op =>
                op.UseNpgsql(configuration.GetConnectionString("PostgreDatabase")));
        }

    }

}

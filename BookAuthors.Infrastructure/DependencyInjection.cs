using BookAuthors.Infrastructure.Persistence;
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
            services.AddDbContext<DatabaseContext>(op =>
                op.UseNpgsql(configuration.GetConnectionString("PostgreDatabase")));
        }

    }
}

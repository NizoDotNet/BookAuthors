using BookAuthors.Application.Service;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookAuthors.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddScoped<AuthorService>();
            services.AddScoped<BookService>();

            return services;
        }
    }
}

using BookAuthors.Application.DTOs.Requests;
using BookAuthors.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthors.Endpoints;

public static class AuthorsEndpointsExtension
{
    extension(RouteGroupBuilder route)
    {
        public RouteGroupBuilder MapAuthorsEndpoints()
        {
            route.MapGet("/", async (int page, int pageSize, [FromServices] AuthorService service, CancellationToken cancellationToken) =>
            {
                return await service.GetAllWithPagination(page, pageSize, cancellationToken);

            });

            route.MapGet("/{authorId}", async (Guid authorId, AuthorService service, CancellationToken cancellationToken) =>
            {
                var author = await service.GetAsync(authorId, cancellationToken);
                if (author == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(author);
            });

            route.MapPost("/", async (CreateAuthorRequest request, AuthorService service, CancellationToken cancellationToken) =>
            {
                var res = await service.CreateAsync(request);
                if (res.Succeeded)
                {
                    return Results.Created();
                }
                return Results.BadRequest(res.Messages);
            });

            return route;
        }
    }
}

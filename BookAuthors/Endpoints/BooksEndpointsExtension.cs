using BookAuthors.Application.DTOs.Requests;
using BookAuthors.Application.Service;

namespace BookAuthors.Endpoints;

public static class BooksEndpointsExtension
{
    extension(RouteGroupBuilder route)
    {
        public RouteGroupBuilder MapBooksEndpoints()
        {
            route.MapGet("/", async (int page, int pageSize, Guid? authorId, BookService service, CancellationToken cancellationToken) =>
            {
                return await service.GetAllWithPaginationAsync(page, pageSize, authorId, cancellationToken);
            });

            route.MapGet("/{bookId}", async (Guid bookId, BookService service, CancellationToken cancellationToken) =>
            {
                var book = await service.GetAsync(bookId, cancellationToken);
                if (book is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(book);
            });

            route.MapPost("/", async (CreateBookRequest createBookRequest, AuthorService service, CancellationToken cancellationToken) =>
            {
                var res = await service.AddBookAsync(createBookRequest, cancellationToken);
                if (res.Succeeded)
                {
                    return Results.Created();
                }
                return Results.BadRequest();
            });

            route.MapPatch("/", async (AddAuthorToBookRequest request, AuthorService service) =>
            {
                var res = await service.AddBookAsync(request.AuthorId, request.BookId);

                if (!res.Succeeded)
                {
                    return Results.BadRequest();
                }

                return Results.Ok();
            })
                .WithDescription("Add author to existing book");
            return route;
        }
    }
}

using BookAuthors.Application;
using BookAuthors.Application.Author;
using BookAuthors.Application.DTOs.Requests;
using BookAuthors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/authors", async (int page, int pageSize, [FromServices] AuthorService service, CancellationToken cancellationToken) =>
{
    return await service.GetAllWithPagination(page, pageSize, cancellationToken);

});

app.MapGet("/authors/{authorId}", async (Guid authorId, [FromServices] AuthorService service, CancellationToken cancellationToken) =>
{
    var author = await service.GetAsync(authorId, cancellationToken);
    if(author == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(author);
});

app.MapPost("/authors", async ([FromBody] CreateAuthorRequest request, AuthorService service, CancellationToken cancellationToken) =>
{
    var res = await service.CreateAsync(request);
    if(res.Succeeded)
    {
        return Results.Created();
    }
    return Results.BadRequest();
});

app.MapPost("/books", async (CreateBookRequest createBookRequest, AuthorService service, CancellationToken cancellationToken) =>
{
    var res = await service.AddBookAsync(createBookRequest);
    if (res.Succeeded)
    {
        return Results.Created();
    }
    return Results.BadRequest();
});
app.Run();



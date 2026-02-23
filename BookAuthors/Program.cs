using BookAuthors.Application;
using BookAuthors.Application.DTOs.Requests;
using BookAuthors.Application.Service;
using BookAuthors.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

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



using BookAuthors.Application;
using BookAuthors.Endpoints;
using BookAuthors.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGroup("/authors")
    .MapAuthorsEndpoints()
    .WithTags("Authors");

app.MapGroup("/books")
    .MapBooksEndpoints()
    .WithTags("Books");


app.Run();



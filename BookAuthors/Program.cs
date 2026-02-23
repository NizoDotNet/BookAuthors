using BookAuthors.Application;
using BookAuthors.Application.DTOs.Requests;
using BookAuthors.Application.Service;
using BookAuthors.Endpoints;
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

app.MapGroup("/authors")
    .MapAuthorsEndpoints()
    .WithTags("Authors")
    .WithName("Authors");

app.MapGroup("/books")
    .MapBooksEndpoints()
    .WithTags("Books")
    .WithName("Books");


app.Run();



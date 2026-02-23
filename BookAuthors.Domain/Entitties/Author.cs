using BookAuthors.Domain.Primitives;

namespace BookAuthors.Domain.Entities;

public class Author : Entity
{
    private readonly List<Book> _books = new();
    public string Name { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string Middlename { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty!;

    public IReadOnlyList<Book> Books => _books.AsReadOnly();

    public void AddBook(Book book)
    {
        _books.Add(book); 
    }

}

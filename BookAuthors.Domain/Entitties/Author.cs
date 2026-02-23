using BookAuthors.Domain.Primitives;

namespace BookAuthors.Domain.Entities;

public class Author : Entity
{
    private readonly List<Book> _books = new();
    public string Name { get; private set; } = null!;
    public string Surame { get; private set; } = null!;
    public string Middlename { get; private set; } = string.Empty;
    public string Bio { get; private set; } = string.Empty!;

    public IReadOnlyList<Book> Books => _books.AsReadOnly();

    public void AddBook(Book book)
    {
        _books.Add(book); 
    }

}

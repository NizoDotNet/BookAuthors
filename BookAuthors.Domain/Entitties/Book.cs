using BookAuthors.Domain.Primitives;

namespace BookAuthors.Domain.Entities;

public class Book : Entity
{

    // For EF CORE
    public Book()
    {
        
    }

    public string Title { get; init; } = null!;
    public List<Author> Authors { get; init; } = [];


}

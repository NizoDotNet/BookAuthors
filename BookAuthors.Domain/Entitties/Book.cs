using BookAuthors.Domain.Primitives;

namespace BookAuthors.Domain.Entities;

public class Book : Entity
{

    // For EF CORE
    public Book()
    {
        
    }

    public string Title { get; private set; } = null!;
    public List<Author> Authors { get; private set; } = [];


}

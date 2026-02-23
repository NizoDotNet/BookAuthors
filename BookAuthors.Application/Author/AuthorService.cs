using BookAuthors.Domain.Repositories;

namespace BookAuthors.Application.Author;

public class AuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

}

using BookAuthors.Domain.Repositories;

namespace BookAuthors.Domain.DomainServices;

internal class AddAuthorToBookDomainService
{
    private readonly IBookRespository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public AddAuthorToBookDomainService(IBookRespository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task AddAuthorToBook(Guid bookId, Guid authorId)
    {
        var book = await _bookRepository.GetAsync(bookId);
        if(book  == null)
        {
            throw new Exception("No book with this Id");
        }

        var author = await _authorRepository.GetAsync(authorId);

        if(author == null)
        {
            throw new Exception("No author with this Id");

        }

        author.AddBook(book);
    }
}

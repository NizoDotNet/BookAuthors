using BookAuthors.Application.DTOs.Responses;
using BookAuthors.Domain.Repositories;

namespace BookAuthors.Application.Service;

public class BookService
{
    private readonly IBookRespository _bookRepository;

    public BookService(IBookRespository bookRepository)
    {
        _bookRepository = bookRepository;
    }


    public async Task<List<BookResponseWithAuthors>> GetAllWithPaginationAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var books = await _bookRepository.GetWithPaginationAsync(page, pageSize, cancellationToken);
        return books.Select(MapToBookResponse)
            .ToList();
    }


    public async Task<BookResponseWithAuthors?> GetAsync(Guid id, Guid? authorId = null, CancellationToken cancellationToken = default)
    {
        var book = await _bookRepository.GetAsync(id, cancellationToken); 
        if(book is null)
        {
            return null;
        }
        return MapToBookResponse(book);
    }


    private static BookResponseWithAuthors MapToBookResponse(Domain.Entities.Book c)
    {
        return new BookResponseWithAuthors
        {
            Title = c.Title,
            Description = c.Description,
            Authors = c.Authors.Select(a => new AuthorInBookResponse()
            {
                Id = a.Id,
                Middlename = a.Middlename,
                Name = a.Name,
                Surname = a.Surname,
            }).ToList()
        };
    }
}

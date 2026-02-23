using BookAuthors.Application.Common;
using BookAuthors.Application.DTOs.Requests;
using BookAuthors.Application.DTOs.Responses;
using BookAuthors.Application.Interfaces;
using BookAuthors.Domain.Entities;
using BookAuthors.Domain.Repositories;
using FluentValidation;

namespace BookAuthors.Application.Author;

public class AuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRespository _bookRespository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateAuthorRequest> _authorValidator;
    private readonly IValidator<CreateBookRequest> _bookValidator;
    public AuthorService(IAuthorRepository authorRepository, IValidator<CreateAuthorRequest> validator, IUnitOfWork unitOfWork, IBookRespository bookRespository, IValidator<CreateBookRequest> bookValidator)
    {
        _authorRepository = authorRepository;
        _authorValidator = validator;
        _unitOfWork = unitOfWork;
        _bookRespository = bookRespository;
        _bookValidator = bookValidator;
    }

    public async Task<List<AuthorResponse>> GetAllWithPagination(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var authors = await _authorRepository.GetWithPaginationAsync(page, pageSize, cancellationToken);
        return authors.Select(c => MapToAuthorResponse(c)).ToList();
    }



    public async Task<AuthorResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var author = await _authorRepository.GetAsync(id, cancellationToken);
        if (author == null)
        {
            return null;
        }
        return MapToAuthorResponse(author);
    }

    public async Task<Result<int>> CreateAsync(CreateAuthorRequest createAuthor, CancellationToken cancellationToken = default)
    {
        var validation = _authorValidator.Validate(createAuthor);
        if (!validation.IsValid)
        {
            var result = Result<int>.Failed(400, -1);
            result.Messages = validation.ToDictionary();
            return result;
        }
        await _authorRepository.InsertAsync(new Domain.Entities.Author()
        {
            Bio = createAuthor.Bio,
            Middlename = createAuthor.Middlename,
            Name = createAuthor.Name,
            Surname = createAuthor.Surname,
        }, cancellationToken);
        int res = await _unitOfWork.SaveAsync(cancellationToken);
        return Result<int>.Succeed(200, res);

    }

    public async Task<Result<int>> AddBookAsync(Guid authorId, Guid bookId)
    {
        var author = await _authorRepository.GetAsync(authorId);
        if (author == null)
        {
            return Result<int>.Failed(404, -1);
        }

        var book = await _bookRespository.GetAsync(bookId);

        if (book == null)
        {
            return Result<int>.Failed(404, -1);
        }

        author.AddBook(book);

        int res = await _unitOfWork.SaveAsync();

        return Result<int>.Succeed(200, res);
    }

    public async Task<Result<int>> AddBookAsync(CreateBookRequest createBook)
    {
        var validation = _bookValidator.Validate(createBook);
        if (!validation.IsValid)
        {
            return Result<int>.Failed(400, -1);
        }
        var author = await _authorRepository.GetAsync(createBook.AuthorId);
        if (author == null)
        {
            return Result<int>.Failed(404, -1);
        }

        var book = new Book()
        {
            Description = createBook.Description,
            Title = createBook.Title,
        };

        author.AddBook(book);

        int res = await _unitOfWork.SaveAsync();

        return Result<int>.Succeed(200, res);
    }
    private static AuthorResponse MapToAuthorResponse(Domain.Entities.Author author)
    {
        return new AuthorResponse()
        {
            Id = author.Id,
            Bio = author.Bio,
            Name = author.Name,
            Surname = author.Surname,
            Middlename = author.Middlename,
            Books = author.Books.Select(b => new BookResponse()
            {
                Description = b.Description,
                Title = b.Title
            }).ToList()
        };
    }
}

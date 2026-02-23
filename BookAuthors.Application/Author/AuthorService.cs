using BookAuthors.Application.Common;
using BookAuthors.Application.DTOs.Requests;
using BookAuthors.Application.DTOs.Responses;
using BookAuthors.Application.Interfaces;
using BookAuthors.Domain.Entities;
using BookAuthors.Domain.Repositories;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BookAuthors.Application.Author;

public class AuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateAuthorRequest> _validator;
    public AuthorService(IAuthorRepository authorRepository, IValidator<CreateAuthorRequest> validator)
    {
        _authorRepository = authorRepository;
        _validator = validator;
    }

    public async Task<List<AuthorResponse>> GetAllWithPagination(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var authors = await _authorRepository.GetWithPaginationAsync(page, pageSize, cancellationToken);
        return authors.Select(c => MapToAuthorResponse(c)).ToList();
    }

    

    public async Task<AuthorResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var author = await _authorRepository.GetAsync(id, cancellationToken);
        if(author == null)
        {
            return null;
        }
        return MapToAuthorResponse(author);
    }
    
    public async Task<Result<int>> CreateAsync(CreateAuthorRequest createAuthor, CancellationToken cancellationToken = default)
    {
        var validation = _validator.Validate(createAuthor);
        if(!validation.IsValid)
        {
            return Result<int>.Failed(400, -1);
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
    private static AuthorResponse MapToAuthorResponse(Domain.Entities.Author author)
    {
        return new AuthorResponse()
        {
            Bio = author.Bio,
            Name = author.Name,
            Surname = author.Surname,
            Middlename = author.Middlename,
            BookResponses = author.Books.Select(b => new BookResponse()
            {
                Description = b.Description,
                Title = b.Title
            }).ToList()
        };
    }
}

namespace BookAuthors.Application.DTOs.Requests;

public record AddAuthorToBookRequest(Guid BookId, Guid AuthorId);

namespace BookAuthors.Application.DTOs.Responses;

public class AuthorInBookResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string Middlename { get; init; } = string.Empty;
}

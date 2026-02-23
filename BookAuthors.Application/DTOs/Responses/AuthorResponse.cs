namespace BookAuthors.Application.DTOs.Responses;

public class AuthorResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string Middlename { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty!;
    public List<BookResponse> Books { get; set; } = [];
}

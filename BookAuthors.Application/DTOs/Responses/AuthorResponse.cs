namespace BookAuthors.Application.DTOs.Responses;

public class AuthorResponse
{
    public string Name { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string Middlename { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty!;
    public List<BookResponse> BookResponses { get; set; } = [];
}

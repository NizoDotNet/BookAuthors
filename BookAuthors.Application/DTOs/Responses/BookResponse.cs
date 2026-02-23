namespace BookAuthors.Application.DTOs.Responses;

public class BookResponse
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = string.Empty;
}

public class BookResponseWithAuthors
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = string.Empty;
    public List<AuthorResponse> Authors { get; set; } = [];
}

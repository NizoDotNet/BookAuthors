namespace BookAuthors.Application.DTOs.Responses;

public class BookResponseWithAuthors
{
    public Guid Id { get; set; }
    public string Title { get; init; } = null!;
    public string Description { get; init; } = string.Empty;
    public List<AuthorInBookResponse> Authors { get; set; } = [];
}

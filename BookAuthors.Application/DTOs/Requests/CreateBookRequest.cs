namespace BookAuthors.Application.DTOs.Requests;

public class CreateBookRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
}

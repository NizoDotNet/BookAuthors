namespace BookAuthors.Application.Author.DTOs.Requests;

public class CreateAuthorRequest
{
    public string Name { get; private set; } = null!;
    public string Surname { get; private set; } = null!;
    public string Middlename { get; private set; } = string.Empty;
    public string Bio { get; private set; } = string.Empty!;
}

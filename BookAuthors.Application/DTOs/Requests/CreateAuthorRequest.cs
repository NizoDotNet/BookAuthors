namespace BookAuthors.Application.DTOs.Requests;

public class CreateAuthorRequest
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Middlename { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty!;
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BookAuthors.Application.DTOs.Requests;

public class CreateBookRequest
{
    public string Title { get; init; } = null!;
    public string Description { get; init; } = string.Empty;
    public Guid AuthorId { get; init; }
}

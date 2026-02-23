using System;
using System.Collections.Generic;
using System.Text;

namespace BookAuthors.Application.DTOs.Requests;

public class CreateBookRequest
{
    public string Title { get; init; } = null!;
    public List<Guid> AuthorsIds { get; init; } = [];
}

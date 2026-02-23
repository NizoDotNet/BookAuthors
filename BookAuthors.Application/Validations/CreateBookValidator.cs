using BookAuthors.Application.DTOs.Requests;
using FluentValidation;

namespace BookAuthors.Application.Validations;

public class CreateBookValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .MaximumLength(255);
    }
}

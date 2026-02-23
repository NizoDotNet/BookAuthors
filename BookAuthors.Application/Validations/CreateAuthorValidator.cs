using BookAuthors.Application.DTOs.Requests;
using FluentValidation;

namespace BookAuthors.Application.Validations;

public class CreateAuthorValidator : AbstractValidator<CreateAuthorRequest>
{
    public CreateAuthorValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(c => c.Surname)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(c => c.Middlename)
            .NotEmpty()
            .MaximumLength(30);

       
    }
}

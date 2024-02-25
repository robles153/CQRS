using CQRS.Application.Members.Commands.CreateMember;
using FluentValidation;

namespace CQRS.Application.Members.Commands.Validations;

public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is required.")
            .Length(4, 100).WithMessage("First Name must be between 4 and 100 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .Length(4, 100).WithMessage("Last Name must be between 4 and 100 characters.");

        RuleFor(x => x.Gender)
            .NotEmpty()
            .MinimumLength(4)
            .WithMessage("The gender must be a valid information");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.");

        RuleFor(x => x.IsActive)
            .NotEmpty().WithMessage("IsActive is required.");

    }
}

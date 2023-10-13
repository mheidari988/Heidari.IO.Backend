namespace backend.Presentation.Validators;

using backend.Application.Portfolios.Commands.ContactMe;
using FluentValidation;

public class ContactMeValidator : AbstractValidator<ContactMeCommand>
{
    public ContactMeValidator()
    {
        _ = this.RuleFor(r => r.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .Length(3, 50).WithMessage("Full name must be between 3 and 50 characters long");

        _ = this.RuleFor(r => r.Email)
            .NotEmpty().EmailAddress().WithMessage("Valid email is required.")
            .MaximumLength(255).WithMessage("Email must not exceed 255 characters");

        _ = this.RuleFor(r => r.Subject)
            .NotEmpty().WithMessage("Subject is required.")
            .Length(3, 100).WithMessage("Subject must be between 3 and 100 characters long");

        _ = this.RuleFor(r => r.Message)
            .NotEmpty().WithMessage("Message is required.")
            .Length(3, 1000).WithMessage("Message must be between 3 and 1000 characters long");
    }
}

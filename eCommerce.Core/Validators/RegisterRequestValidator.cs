using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Enter a valid email")
                .MaximumLength(50).WithMessage("The email should not be more than 50 characters");

            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(temp => temp.PersonName)
                .NotEmpty().WithMessage("PersonName is required.")
                .MaximumLength(50).WithMessage("PersonName should not be longer than 50 characters.");

            RuleFor(temp => temp.Gender)
                .NotEmpty().WithMessage("Gender is required");
        }
    }
}

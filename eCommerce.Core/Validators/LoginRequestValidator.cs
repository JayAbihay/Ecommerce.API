using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        // EMAIL 

        public LoginRequestValidator()
        {

            RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid address format");

            // PASSWORD 

            RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");

        }
    }
}

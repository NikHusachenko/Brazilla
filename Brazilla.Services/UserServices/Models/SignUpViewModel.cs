using FluentValidation;

namespace Brazilla.Services.UserServices.Models
{
    public class SignUpViewModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class SignUpValidator : AbstractValidator<SignUpViewModel>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.Email).EmailAddress().MaximumLength(31).NotEmpty().NotNull();
            RuleFor(x => x.Login).Length(3, 15).NotEmpty().NotNull();
            RuleFor(x => x.Password).Length(4, 15).NotEmpty().NotNull();
        }
    }
}

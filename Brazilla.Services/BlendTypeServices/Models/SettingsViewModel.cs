using FluentValidation;

namespace Brazilla.Services.BlendTypeServices.Models
{
    public class SettingsViewModel
    {
        public string Name { get; set; }
        public int Arabica { get; set; }
        public int Robusta { get; set; }
    }

    public class SettingsValidator : AbstractValidator<SettingsViewModel>
    {
        public SettingsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(3, 31);
        }
    }
}

using Brazilla.Database.Entities;
using FluentValidation;

namespace Brazilla.Services.BlendServices.Models
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public int Left { get; set; }
        public long SelectedType { get; set; }
    }

    public class CreateValidator : AbstractValidator<CreateViewModel>
    {
        public CreateValidator()
        {
            RuleFor(x => x.Description).Length(7, 511).NotEmpty().NotNull();
            RuleFor(x => x.Left).NotEmpty().NotNull();
            RuleFor(x => x.Name).Length(3, 15).NotEmpty().NotNull();
            RuleFor(x => x.Price).NotEmpty().NotNull();
            RuleFor(x => x.Weight).NotEmpty().NotNull();
        }
    }
}
using FluentValidation;
using WarriorFightClub.Application.Features.Services.Commands.CreateService;

namespace WarriorFightClub.Application.Validations.ServiceValidators
{
    public sealed class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(500);
        }
    }
}

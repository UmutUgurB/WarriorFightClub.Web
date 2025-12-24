using FluentValidation;
using WarriorFightClub.Application.Features.Services.Commands.UpdateService;

namespace WarriorFightClub.Application.Validations.ServiceValidators
{
    public sealed class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(500);
        }
    }
}

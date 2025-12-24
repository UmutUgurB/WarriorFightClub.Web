using FluentValidation;
using WarriorFightClub.Application.Features.Abouts.Commands.UpdateAbout;

namespace WarriorFightClub.Application.Validations.AboutValidators
{
    public sealed class UpdateAboutCommandValidator : AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Title)
                .NotEmpty().MaximumLength(200);

            RuleFor(x => x.SubTitle)
                .NotEmpty().MaximumLength(250);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.ImageUrl)
                .NotEmpty().MaximumLength(500);
        }
    }
}

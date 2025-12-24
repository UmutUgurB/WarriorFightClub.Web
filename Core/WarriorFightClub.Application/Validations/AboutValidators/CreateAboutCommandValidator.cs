using FluentValidation;
using WarriorFightClub.Application.Features.Abouts.Commands.CreateAbout;

namespace WarriorFightClub.Application.Validations.AboutValidators
{
    public sealed class CreateAboutCommandValidator : AbstractValidator<CreateAboutCommand>
    {
        public CreateAboutCommandValidator()
        {
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

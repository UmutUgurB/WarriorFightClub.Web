using FluentValidation;
using WarriorFightClub.Application.Features.Banners.Commands.CreateBanner;

namespace WarriorFightClub.Application.Validations.BannerValidators
{
    public sealed class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.SubTitle).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Button).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(500);
        }
    }
}

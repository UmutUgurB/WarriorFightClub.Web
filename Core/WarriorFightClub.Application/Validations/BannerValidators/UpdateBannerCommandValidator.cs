using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Features.Banners.Commands.UpdateBanner;

namespace WarriorFightClub.Application.Validations.BannerValidators
{
    public sealed class UpdateBannerCommandValidator : AbstractValidator<UpdateBannerCommand>
    {
        public UpdateBannerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
            RuleFor(x => x.SubTitle).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Button).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(500);
        }
    }
}

using FluentValidation;
using WarriorFightClub.Application.Features.Banners.Queries.GetAllBanners;

namespace WarriorFightClub.Application.Validations.BannerValidators
{
    public class GetAllBannersQueryValidator :AbstractValidator<GetAllBannersQuery>
    {
        public GetAllBannersQueryValidator()
        {
            RuleFor(x=>x.PageSize).GreaterThanOrEqualTo(1);
            RuleFor(x=>x.Page).InclusiveBetween(1, 100);
        }
    }
}

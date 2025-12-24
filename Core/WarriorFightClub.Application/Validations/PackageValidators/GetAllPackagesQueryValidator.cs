using FluentValidation;
using WarriorFightClub.Application.Features.Packages.Queries.GetAllPackages;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Validations.PackageValidators
{
    public class GetAllPackagesQueryValidator : AbstractValidator<GetAllPackagesQuery>
    {
        public GetAllPackagesQueryValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Page).InclusiveBetween(1, 100);

        }
    }
}

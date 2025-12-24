using FluentValidation;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Validations.PackageValidators
{
    public class CreatePackageCommandValidator : AbstractValidator<Package>
    {
        public CreatePackageCommandValidator()
        {
            RuleFor(x=>x.Title).NotEmpty(); 


        }
    }
}

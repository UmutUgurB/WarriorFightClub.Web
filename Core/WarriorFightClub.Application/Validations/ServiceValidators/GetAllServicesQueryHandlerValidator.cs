using FluentValidation;
using WarriorFightClub.Application.Features.Services.Queries.GetAllServices;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Validations.ServiceValidators
{
    public class GetAllServicesQueryHandlerValidator : AbstractValidator<GetAllServicesQuery>
    {
        public GetAllServicesQueryHandlerValidator()
        {
           RuleFor(x=>x.PageSize).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Page).InclusiveBetween(1, 100);

        }
    }
}

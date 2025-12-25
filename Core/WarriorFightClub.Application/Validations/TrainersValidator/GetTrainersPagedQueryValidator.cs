using FluentValidation;
using WarriorFightClub.Application.Features.Trainers.Queries.GetTrainersPaged;

namespace WarriorFightClub.Application.Validations.TrainersValidator
{
    public sealed class GetTrainersPagedQueryValidator : AbstractValidator<GetTrainersPagedQuery>
    {
        public GetTrainersPagedQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
        }
    }
}

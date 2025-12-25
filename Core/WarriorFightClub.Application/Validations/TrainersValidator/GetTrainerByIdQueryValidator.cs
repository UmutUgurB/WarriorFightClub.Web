using FluentValidation;
using WarriorFightClub.Application.Features.Trainers.Queries.GetTrainerById;

namespace WarriorFightClub.Application.Validations.TrainersValidator
{
    public sealed class GetTrainerByIdQueryValidator : AbstractValidator<GetTrainerByIdQuery>
    {
        public GetTrainerByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

using FluentValidation;
using WarriorFightClub.Application.Features.Trainers.Commands.CreateTrainer;

namespace WarriorFightClub.Application.Validations.TrainersValidator
{
    public sealed class CreateTrainerCommandValidator : AbstractValidator<CreateTrainerCommand>
    {
        public CreateTrainerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(500);

            RuleFor(x => x.BirthDate)
                .Must(d => d is null || d <= DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage("BirthDate cannot be in the future.");
        }
    }
}

using MediatR;

namespace WarriorFightClub.Application.Features.Trainers.Commands.CreateTrainer
{
    public sealed record CreateTrainerCommand(
    string Name,
    string Surname,
    string Description,
    DateOnly? BirthDate,
    string ImageUrl,
    bool IsActive
) : IRequest<Guid>;
}

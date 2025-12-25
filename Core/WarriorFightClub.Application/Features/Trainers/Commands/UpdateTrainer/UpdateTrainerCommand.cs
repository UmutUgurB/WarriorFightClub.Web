using MediatR;

namespace WarriorFightClub.Application.Features.Trainers.Commands.UpdateTrainer
{
    public sealed record UpdateTrainerCommand(
     Guid Id,
     string Name,
     string Surname,
     string Description,
     DateOnly? BirthDate,
     string ImageUrl,
     bool IsActive
 ) : IRequest<bool>;
}

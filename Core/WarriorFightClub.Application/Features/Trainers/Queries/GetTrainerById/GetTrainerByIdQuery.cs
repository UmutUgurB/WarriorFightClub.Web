using MediatR;
using WarriorFightClub.Application.Features.Trainers.Dtos;

namespace WarriorFightClub.Application.Features.Trainers.Queries.GetTrainerById
{
    public sealed record GetTrainerByIdQuery(Guid Id) : IRequest<TrainerDto?>;
}

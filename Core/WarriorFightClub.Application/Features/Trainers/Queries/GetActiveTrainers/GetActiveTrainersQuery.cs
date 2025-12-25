using MediatR;
using WarriorFightClub.Application.Features.Trainers.Dtos;

namespace WarriorFightClub.Application.Features.Trainers.Queries.GetActiveTrainers
{
    public sealed record GetActiveTrainersQuery : IRequest<List<TrainerDto>>;
}

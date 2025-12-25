using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Trainers.Dtos;

namespace WarriorFightClub.Application.Features.Trainers.Queries.GetTrainersPaged
{
    public sealed record GetTrainersPagedQuery(int Page = 1, int PageSize = 20, bool? IsActive = null)
    : IRequest<PagedResult<TrainerDto>>;
}

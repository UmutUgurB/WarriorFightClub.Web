using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Services.Dtos;

namespace WarriorFightClub.Application.Features.Services.Queries.GetAllServices
{
    public sealed record GetAllServicesQuery(int Page = 1 ,int PageSize =20 , bool? IsActive = null,CancellationToken ct = default) : IRequest<PagedResult<ServiceDto>>
    {
    }
}

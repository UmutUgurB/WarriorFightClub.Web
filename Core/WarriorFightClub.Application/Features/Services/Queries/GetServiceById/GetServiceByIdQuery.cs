using MediatR;
using WarriorFightClub.Application.Features.Services.Dtos;

namespace WarriorFightClub.Application.Features.Services.Queries.GetServiceById
{
    public sealed record GetServiceByIdQuery(Guid Id): IRequest<ServiceDto?>
    {
    }
}

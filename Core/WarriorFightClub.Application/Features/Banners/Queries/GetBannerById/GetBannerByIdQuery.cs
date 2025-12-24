using MediatR;
using WarriorFightClub.Application.Features.Banners.Dtos;

namespace WarriorFightClub.Application.Features.Banners.Queries.GetBannerById
{
    public sealed record GetBannerByIdQuery(Guid Id) : IRequest<BannerDto?>;
}

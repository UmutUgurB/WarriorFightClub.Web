using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Banners.Dtos;

namespace WarriorFightClub.Application.Features.Banners.Queries.GetAllBanners
{
    public sealed record GetAllBannersQuery(int Page = 1, int PageSize = 20, bool? IsActive = null)
    : IRequest<PagedResult<BannerDto>>;
}

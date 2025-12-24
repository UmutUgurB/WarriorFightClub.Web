using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Banners.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Repositories.Banners
{
    public interface IBannerRepository : IGenericRepository<Banner>
    {
        Task<Banner?> GetActiveLatestAsync(CancellationToken cancellationToken = default);
        Task<PagedResult<Banner>> GetPagedAsync(int page, int pageSize, bool? isActive, CancellationToken ct = default);

    }
}

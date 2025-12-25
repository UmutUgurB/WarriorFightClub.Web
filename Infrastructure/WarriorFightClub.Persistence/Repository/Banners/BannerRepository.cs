using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Repositories.Banners;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.Banners
{
    public class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<List<Banner>> GetActiveListAsync(CancellationToken ct = default)
        {
            return Table.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync(ct);
        }

        public Task<Banner?> GetActiveLatestAsync(CancellationToken ct = default)
        {
            return Table.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefaultAsync(ct);
        }

        public async Task<PagedResult<Banner>> GetPagedAsync(int page, int pageSize, bool? isActive, CancellationToken ct = default)
        {

            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 20;


            IQueryable<Banner> query = Table.AsNoTracking();

            if (isActive.HasValue)
                query = query.Where(x => x.IsActive == isActive.Value);

            query = query.OrderByDescending(x => x.CreatedDate);


            var totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Banner>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                Items = items
            };
        }
    }
}

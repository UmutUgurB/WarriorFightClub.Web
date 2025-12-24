using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Repositories.Services;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.Services
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<List<Service>> GetActiveListAsync(CancellationToken ct = default)
        {
            return Table.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderByDescending(x=>x.CreatedDate)
                .ToListAsync(ct);
        }

        public async Task<PagedResult<Service>> GetPagedAsync(int page, int pageSize, bool? isActive, CancellationToken ct = default)
        {
            if(page < 1) page = 1;
            if(pageSize < 20) pageSize = 20;

            IQueryable<Service> query = Table.AsNoTracking();   

            if(isActive.HasValue)
                query = query.Where(x=> x.IsActive == isActive.Value);

            query = query.OrderByDescending(x => x.CreatedDate);

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((page-1) * pageSize) 
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Service>
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

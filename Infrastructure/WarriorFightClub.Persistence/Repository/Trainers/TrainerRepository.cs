using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Repositories;
using WarriorFightClub.Application.Repositories.Testimonials;
using WarriorFightClub.Application.Repositories.Trainers;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.Trainers
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<List<Trainer>> GetActiveTrainersAsync(CancellationToken cancellationToken = default)
        {
            return Table.AsNoTracking()
            .Where(x => x.IsActive)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync(cancellationToken);

        }

        public async  Task<PagedResult<Trainer>> GetPagedAsync(int page, int pageSize, bool? isActive, CancellationToken ct = default)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 20;

            IQueryable<Trainer> query = Table.AsNoTracking();

            if (isActive.HasValue)
                query = query.Where(x => x.IsActive == isActive.Value);

            query = query.OrderByDescending(x => x.CreatedDate);

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Trainer>
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

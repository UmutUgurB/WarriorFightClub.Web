using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Repositories.Testimonials;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.Testimonials
{
    public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<PagedResult<Testimonial>> GetPagedAsync(int page, int pageSize, bool? isShown, CancellationToken ct = default)
        {
            if(page< 1) page = 1;   
            if(pageSize < 1) pageSize = 20;
            if (pageSize > 100) pageSize = 100;
            IQueryable<Testimonial> query = Table.AsNoTracking();

            if(isShown.HasValue)
                query = query.Where(x=>x.IsShown == isShown.Value);
            query = query.OrderByDescending(x=> x.CreatedDate); 

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
            return new PagedResult<Testimonial>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                Items = items
            };
        }

        public Task<List<Testimonial>> GetShownListAsync(CancellationToken ct = default)
        {
            return Table.AsNoTracking()
                .Where(x=>x.IsShown)
                .OrderByDescending(x=>x.CreatedDate)
                .ToListAsync(ct);
        }
    }
}

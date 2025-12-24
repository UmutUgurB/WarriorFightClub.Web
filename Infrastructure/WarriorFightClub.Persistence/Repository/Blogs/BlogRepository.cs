using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Repositories.Blogs;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Domain.Enums;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.Blogs
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<PagedResult<Blog>> GetPagedWithCategoryAsync(
        int page,
        int pageSize,
        Guid? categoryId,
        BlogStatus? status,
        CancellationToken ct = default)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 20;

            IQueryable<Blog> query = Table
                .AsNoTracking()
                .Include(x => x.Category); 

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            if (status.HasValue)
                query = query.Where(x => x.Status == status.Value);

            query = query.OrderByDescending(x => x.CreatedDate);

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<Blog>
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

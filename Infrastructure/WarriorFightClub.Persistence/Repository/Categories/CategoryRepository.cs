using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Categories.Dtos;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<PagedResult<CategoryAdminDto>> GetPagedWithBlogCountAsync(int page, int pageSize, CancellationToken ct = default)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 20;
            if (pageSize > 100) pageSize = 100;

            var query = Table.AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .Select(c => new CategoryAdminDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedDate = c.CreatedDate,
                    BlogCount = c.Blogs.Count()
                });

            var totalCount = await query.CountAsync(ct);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return new PagedResult<CategoryAdminDto>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                Items = items
            };
        }

        public Task<List<CategoryLookupDto>> GetLookupAsync(CancellationToken ct = default)
            => Table.AsNoTracking()
                .OrderBy(x => x.Title)
                .Select(x => new CategoryLookupDto { Id = x.Id, Title = x.Title })
                .ToListAsync(ct);

        public Task<CategoryDetailDto?> GetDetailAsync(Guid id, CancellationToken ct = default)
            => Table.AsNoTracking()
                .Where(x => x.Id == id)
                .Select(c => new CategoryDetailDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedDate = c.CreatedDate,
                    BlogCount = c.Blogs.Count()
                })
                .FirstOrDefaultAsync(ct);

        public Task<bool> ExistsByTitleAsync(string title, Guid? excludeId = null, CancellationToken ct = default)
        {
            var q = Table.AsNoTracking().Where(x => x.Title == title);
            if (excludeId.HasValue) q = q.Where(x => x.Id != excludeId.Value);
            return q.AnyAsync(ct);
        }
    }
}

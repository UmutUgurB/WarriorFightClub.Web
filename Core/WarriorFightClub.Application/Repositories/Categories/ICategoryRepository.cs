using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Categories.Dtos;
using WarriorFightClub.Application.Repositories;
using WarriorFightClub.Domain.Entities;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<PagedResult<CategoryAdminDto>> GetPagedWithBlogCountAsync(int page, int pageSize, CancellationToken ct = default);
    Task<List<CategoryLookupDto>> GetLookupAsync(CancellationToken ct = default);
    Task<CategoryDetailDto?> GetDetailAsync(Guid id, CancellationToken ct = default);

    Task<bool> ExistsByTitleAsync(string title, Guid? excludeId = null, CancellationToken ct = default);
}

using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Application.Repositories.Blogs
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<PagedResult<Blog>> GetPagedWithCategoryAsync(
        int page,
        int pageSize,
        Guid? categoryId,
        BlogStatus? status,
        CancellationToken ct = default);
    }
}

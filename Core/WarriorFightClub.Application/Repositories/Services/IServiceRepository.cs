using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Repositories.Services
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<List<Service>> GetActiveListAsync(CancellationToken ct = default);
        Task<PagedResult<Service>> GetPagedAsync( int page, int pageSize,bool? isActive, CancellationToken ct = default);
    }
}

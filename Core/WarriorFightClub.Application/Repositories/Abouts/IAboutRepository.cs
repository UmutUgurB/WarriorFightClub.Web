using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Repositories.Abouts
{
    public interface IAboutRepository : IGenericRepository<About>
    {
        Task<About?> GetActiveAsync(CancellationToken ct = default);
    }
}

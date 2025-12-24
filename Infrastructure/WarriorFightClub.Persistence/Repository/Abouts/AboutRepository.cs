using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Repositories.Abouts;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.Abouts
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<About?> GetActiveAsync(CancellationToken ct = default)
        {
            return Table.AsNoTracking()
                .Where(x => x.IsActive)
                .OrderByDescending(x=>x.CreatedDate)    
                .FirstOrDefaultAsync(ct);
        }
    }
}

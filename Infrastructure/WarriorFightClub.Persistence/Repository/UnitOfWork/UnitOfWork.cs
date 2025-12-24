using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db) => _db = db;

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}

using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Application.Repositories;
using WarriorFightClub.Domain.Common;
using WarriorFightClub.Persistence.Contexts;

namespace WarriorFightClub.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected DbSet<T> Table=> _appDbContext.Set<T>();
        public async Task AddAsync(T entity, CancellationToken ct = default)=> await Table.AddAsync(entity, ct);    

        public IQueryable<T> GetAll(bool tracking = false)
        {
            var query = Table.AsQueryable();
            if(!tracking)
                query = query.AsNoTracking();
            return query;   
        }

        public async Task<T?> GetByIdAsync(Guid id, bool tracking = false, CancellationToken ct = default)
        {
            var query = tracking ? Table : Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(x=> x.Id == id,ct);
        }

        public void Remove(T entity)=>Table.Remove(entity);

        public void Update(T entity)=> Table.Update(entity);
    }
}

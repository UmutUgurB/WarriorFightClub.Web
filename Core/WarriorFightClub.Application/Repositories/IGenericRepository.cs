using WarriorFightClub.Domain.Common;

namespace WarriorFightClub.Application.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id, bool tracking = false, CancellationToken ct = default);
        IQueryable<T> GetAll(bool tracking = false);

        Task AddAsync(T entity, CancellationToken ct = default);
        void Update(T entity);
        void Remove(T entity);

    }
}

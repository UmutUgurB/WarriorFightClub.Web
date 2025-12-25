using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Repositories.Trainers
{
    public interface  ITrainerRepository : IGenericRepository<Trainer>
    {
        Task<List<Trainer>> GetActiveTrainersAsync(CancellationToken cancellationToken = default);  
        Task<PagedResult<Trainer>> GetPagedAsync(int page,int pageSize, bool? isActive, CancellationToken cancellationToken = default); 

    }
}

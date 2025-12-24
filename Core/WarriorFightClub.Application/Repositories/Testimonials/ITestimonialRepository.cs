using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Repositories.Testimonials
{
    public interface ITestimonialRepository : IGenericRepository<Testimonial> 
    {
        Task<List<Testimonial>> GetShownListAsync(CancellationToken ct = default);

        Task<PagedResult<Testimonial>> GetPagedAsync(
            int page,
            int pageSize,
            bool? isShown,
            CancellationToken ct = default);
    }
}

using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Testimonials.Dtos;

namespace WarriorFightClub.Application.Features.Testimonials.Queries.GetAllTestimonials
{
    public sealed record GetTestimonialsPagedQuery(int Page = 1, int PageSize = 20, bool? IsShown = null)
    : IRequest<PagedResult<TestimonialDto>>;
}

using MediatR;
using WarriorFightClub.Application.Features.Testimonials.Dtos;

namespace WarriorFightClub.Application.Features.Testimonials.Queries.GetAllTestimonials
{
    public sealed record GetShownTestimonialsQuery : IRequest<List<TestimonialDto>>;

}

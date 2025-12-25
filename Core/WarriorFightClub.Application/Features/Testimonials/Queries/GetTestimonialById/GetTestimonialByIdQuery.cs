using MediatR;
using WarriorFightClub.Application.Features.Testimonials.Dtos;

namespace WarriorFightClub.Application.Features.Testimonials.Queries.GetTestimonialById
{
    public sealed record GetTestimonialByIdQuery(Guid Id) : IRequest<TestimonialDto?>;
}

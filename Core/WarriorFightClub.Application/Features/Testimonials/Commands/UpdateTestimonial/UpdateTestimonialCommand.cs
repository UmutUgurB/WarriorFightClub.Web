using MediatR;

namespace WarriorFightClub.Application.Features.Testimonials.Commands.UpdateTestimonial
{
    public sealed record UpdateTestimonialCommand(
    Guid Id,
    string Title,
    string Description,
    bool IsShown
) : IRequest<bool>;
}

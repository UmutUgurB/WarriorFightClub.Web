using FluentValidation;
using WarriorFightClub.Application.Features.Testimonials.Queries.GetTestimonialById;

namespace WarriorFightClub.Application.Validations.TestimonialValidator
{
    public sealed class GetTestimonialByIdQueryValidator : AbstractValidator<GetTestimonialByIdQuery>
    {
        public GetTestimonialByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}

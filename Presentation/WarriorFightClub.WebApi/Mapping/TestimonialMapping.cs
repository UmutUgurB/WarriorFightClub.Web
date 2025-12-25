using AutoMapper;
using WarriorFightClub.Application.Features.Testimonials.Commands.CreateTestimonial;
using WarriorFightClub.Application.Features.Testimonials.Commands.UpdateTestimonial;
using WarriorFightClub.WebApi.Contracts.Testimonials;

namespace WarriorFightClub.WebApi.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialRequest, CreateTestimonialCommand>();

            CreateMap<UpdateTestimonialRequest, UpdateTestimonialCommand>()
                .ForCtorParam("Id", opt => opt.MapFrom(_ => Guid.Empty));
        }
    }
}
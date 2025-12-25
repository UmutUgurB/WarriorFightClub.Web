using AutoMapper;
using WarriorFightClub.Application.Features.Testimonials.Commands.CreateTestimonial;
using WarriorFightClub.Application.Features.Testimonials.Commands.UpdateTestimonial;
using WarriorFightClub.Application.Features.Testimonials.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Mapping
{
    public class TestimonialProfile : Profile
    {

        public TestimonialProfile()
        {

            CreateMap<Testimonial, TestimonialDto>();


            CreateMap<CreateTestimonialCommand, Testimonial>();


            CreateMap<UpdateTestimonialCommand, Testimonial>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore());
        }
    }
}

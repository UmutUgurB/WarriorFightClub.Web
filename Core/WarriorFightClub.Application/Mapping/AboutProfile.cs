using AutoMapper;
using WarriorFightClub.Application.Features.Abouts.Commands.CreateAbout;
using WarriorFightClub.Application.Features.Abouts.Commands.UpdateAbout;
using WarriorFightClub.Application.Features.Abouts.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Mapping
{
    public sealed class AboutProfile : Profile
    {
        public AboutProfile()
        {

            CreateMap<About, AboutDto>();

            CreateMap<CreateAboutCommand, About>();

            CreateMap<UpdateAboutCommand, About>();
        }
    }
}

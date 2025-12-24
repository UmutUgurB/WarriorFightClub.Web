using AutoMapper;
using WarriorFightClub.Application.Features.Abouts.Commands.CreateAbout;
using WarriorFightClub.Application.Features.Abouts.Commands.UpdateAbout;
using WarriorFightClub.WebApi.Contracts.Abouts;

namespace WarriorFightClub.WebApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutRequest, CreateAboutCommand>();
            CreateMap<UpdateAboutRequest, UpdateAboutCommand>()
                .ForCtorParam("Id", opt => opt.MapFrom(_ => Guid.Empty));
        }
    }
}

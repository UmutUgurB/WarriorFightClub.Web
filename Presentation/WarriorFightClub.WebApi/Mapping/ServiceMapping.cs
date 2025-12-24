using AutoMapper;
using WarriorFightClub.Application.Features.Services.Commands.CreateService;
using WarriorFightClub.Application.Features.Services.Commands.UpdateService;
using WarriorFightClub.WebApi.Contracts.Services;

namespace WarriorFightClub.WebApi.Mapping
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<UpdateServiceCommand, UpdateServiceRequest>();
            CreateMap<CreateServiceCommand,CreateServiceRequest>();

        }
    }
}

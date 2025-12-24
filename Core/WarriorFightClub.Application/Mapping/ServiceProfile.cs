using AutoMapper;
using WarriorFightClub.Application.Features.Services.Commands.CreateService;
using WarriorFightClub.Application.Features.Services.Commands.UpdateService;
using WarriorFightClub.Application.Features.Services.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Mapping
{
    public  class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>();
            CreateMap<Service,UpdateServiceCommand>();  
            CreateMap<Service,CreateServiceCommand>();  
        }
    }
}

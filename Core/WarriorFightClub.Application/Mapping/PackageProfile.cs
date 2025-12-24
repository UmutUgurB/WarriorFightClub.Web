using AutoMapper;
using WarriorFightClub.Application.Features.Packages.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Mapping
{
    public  class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<Package,PackageDto>();    


        }
    }
}

using AutoMapper;
using WarriorFightClub.Application.Features.Packages.Commands.CreatePackage;
using WarriorFightClub.Application.Features.Packages.Commands.UpdatePackage;
using WarriorFightClub.WebApi.Contracts.Packages;

namespace WarriorFightClub.WebApi.Mapping
{
    public class PackageMapping : Profile
    {
        public PackageMapping()
        {
            CreateMap<CreatePackageCommand, CreatePackageRequest>();
            CreateMap<UpdatePackageCommand, UpdatePackageRequest>();
        }
    }
}

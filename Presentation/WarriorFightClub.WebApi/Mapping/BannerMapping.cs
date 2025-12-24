using AutoMapper;
using WarriorFightClub.Application.Features.Banners.Commands.CreateBanner;
using WarriorFightClub.Application.Features.Banners.Commands.UpdateBanner;
using WarriorFightClub.WebApi.Contracts.Banners;

namespace WarriorFightClub.WebApi.Mapping
{
    public sealed class BannerApiProfile : Profile
    {
        public BannerApiProfile()
        {
            CreateMap<CreateBannerRequest, CreateBannerCommand>();

            CreateMap<UpdateBannerRequest, UpdateBannerCommand>()
                .ForCtorParam("Id", opt => opt.MapFrom(_ => Guid.Empty));
        }
    }
}

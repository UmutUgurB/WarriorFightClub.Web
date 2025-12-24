using AutoMapper;
using WarriorFightClub.Application.Features.Banners.Commands.CreateBanner;
using WarriorFightClub.Application.Features.Banners.Commands.UpdateBanner;
using WarriorFightClub.Application.Features.Banners.Dtos;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Mapping
{
    public sealed class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<Banner, BannerDto>();

            CreateMap<CreateBannerCommand, Banner>();

            CreateMap<UpdateBannerCommand, Banner>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore());
        }
    }
}

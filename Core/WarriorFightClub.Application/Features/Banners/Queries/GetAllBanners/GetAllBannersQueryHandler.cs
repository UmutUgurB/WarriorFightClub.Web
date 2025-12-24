using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Banners.Dtos;
using WarriorFightClub.Application.Repositories.Banners;

namespace WarriorFightClub.Application.Features.Banners.Queries.GetAllBanners
{
    public class GetAllBannersQueryHandler : IRequestHandler<GetAllBannersQuery, PagedResult<BannerDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBannerRepository _bannerRepository;

        public GetAllBannersQueryHandler(IMapper mapper, IBannerRepository bannerRepository)
        {
            _mapper = mapper;
            _bannerRepository = bannerRepository;
        }

        public async Task<PagedResult<BannerDto>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken)
        {
            var paged = await _bannerRepository.GetPagedAsync(request.Page, request.PageSize, request.IsActive, cancellationToken);

            return new PagedResult<BannerDto>
            {
                Page = paged.Page,
                PageSize = paged.PageSize,
                TotalCount = paged.TotalCount,
                TotalPages = paged.TotalPages,
                Items = _mapper.Map<List<BannerDto>>(paged.Items)
            };
        }
    }
}

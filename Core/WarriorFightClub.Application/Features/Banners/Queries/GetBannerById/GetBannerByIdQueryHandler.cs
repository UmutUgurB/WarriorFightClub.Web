using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Features.Banners.Dtos;
using WarriorFightClub.Application.Repositories.Banners;

namespace WarriorFightClub.Application.Features.Banners.Queries.GetBannerById
{
    public sealed class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, BannerDto?>
    {
        private readonly IBannerRepository _repo;
        private readonly IMapper _mapper;

        public GetBannerByIdQueryHandler(IBannerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BannerDto?> Handle(GetBannerByIdQuery request, CancellationToken ct)
        {
            var banner = await _repo.GetByIdAsync(request.Id, tracking: false, ct);
            return banner is null ? null : _mapper.Map<BannerDto>(banner);
        }
    }
}

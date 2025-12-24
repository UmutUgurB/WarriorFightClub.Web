using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Banners;
using WarriorFightClub.Application.Repositories.UnitOfWork;

namespace WarriorFightClub.Application.Features.Banners.Commands.UpdateBanner
{
    public sealed class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand, bool>
    {
        private readonly IBannerRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateBannerCommandHandler(IBannerRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _repo = repo;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBannerCommand request, CancellationToken ct)
        {
            var banner = await _repo.GetByIdAsync(request.Id, tracking: true, ct);
            if (banner is null) return false;

            _mapper.Map(request, banner);

            _repo.Update(banner);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}

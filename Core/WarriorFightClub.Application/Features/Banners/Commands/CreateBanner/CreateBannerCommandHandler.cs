using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Banners;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Features.Banners.Commands.CreateBanner
{
    public sealed class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand, Guid>
    {
        private readonly IBannerRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateBannerCommandHandler(IBannerRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _repo = repo;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateBannerCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Banner>(request);
            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);
            return entity.Id;
        }
    }
}

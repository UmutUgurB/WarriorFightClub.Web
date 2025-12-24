using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Abouts;
using WarriorFightClub.Application.Repositories.UnitOfWork;

namespace WarriorFightClub.Application.Features.Abouts.Commands.UpdateAbout
{
    public sealed class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, bool>
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IAboutRepository aboutRepository, IUnitOfWork uow, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAboutCommand request, CancellationToken ct)
        {
            var about = await _aboutRepository.GetByIdAsync(request.Id, tracking: true, ct);
            if (about is null) return false;

            _mapper.Map(request, about); 

            _aboutRepository.Update(about);
            await _uow.SaveChangesAsync(ct);

            return true;
        }
    }
}

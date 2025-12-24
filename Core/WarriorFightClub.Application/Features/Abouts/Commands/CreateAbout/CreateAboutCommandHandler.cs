using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Abouts;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Features.Abouts.Commands.CreateAbout
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, Guid>
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateAboutCommandHandler(IAboutRepository aboutRepository, IUnitOfWork uow, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<About>(request);
            await _aboutRepository.AddAsync(entity,cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

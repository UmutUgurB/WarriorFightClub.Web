using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Services;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Features.Services.Commands.CreateService
{
    public sealed record CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Guid>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreateServiceCommandHandler(IMapper mapper, IServiceRepository serviceRepository, IUnitOfWork uow)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Service>(request);
            await _serviceRepository.AddAsync(entity, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}

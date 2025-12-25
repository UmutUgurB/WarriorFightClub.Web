using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Trainers;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Features.Trainers.Commands.CreateTrainer
{
    public sealed class CreateTrainerCommandHandler : IRequestHandler<CreateTrainerCommand, Guid>
    {
        private readonly ITrainerRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateTrainerCommandHandler(ITrainerRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _repo = repo;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTrainerCommand request, CancellationToken ct)
        {
            var entity = _mapper.Map<Trainer>(request);

            await _repo.AddAsync(entity, ct);
            await _uow.SaveChangesAsync(ct);

            return entity.Id;
        }
    }
}

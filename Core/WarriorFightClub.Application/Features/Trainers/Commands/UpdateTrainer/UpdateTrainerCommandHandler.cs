using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorFightClub.Application.Repositories.Trainers;
using WarriorFightClub.Application.Repositories.UnitOfWork;

namespace WarriorFightClub.Application.Features.Trainers.Commands.UpdateTrainer
{
    public sealed class UpdateTrainerCommandHandler : IRequestHandler<UpdateTrainerCommand, bool>
    {
        private readonly ITrainerRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateTrainerCommandHandler(ITrainerRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _repo = repo;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateTrainerCommand request, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id, tracking: true, ct);
            if (entity is null) return false;

            _mapper.Map(request, entity);

            _repo.Update(entity);
            await _uow.SaveChangesAsync(ct);

            return true;
        }
    }
}

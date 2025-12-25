using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Features.Trainers.Dtos;
using WarriorFightClub.Application.Repositories.Trainers;

namespace WarriorFightClub.Application.Features.Trainers.Queries.GetTrainerById
{
    public sealed class GetTrainerByIdQueryHandler : IRequestHandler<GetTrainerByIdQuery, TrainerDto?>
    {
        private readonly ITrainerRepository _repo;
        private readonly IMapper _mapper;

        public GetTrainerByIdQueryHandler(ITrainerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TrainerDto?> Handle(GetTrainerByIdQuery request, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(request.Id, tracking: false, ct);
            return entity is null ? null : _mapper.Map<TrainerDto>(entity);
        }
    }

}

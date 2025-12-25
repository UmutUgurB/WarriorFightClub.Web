using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Features.Trainers.Dtos;
using WarriorFightClub.Application.Repositories.Trainers;

namespace WarriorFightClub.Application.Features.Trainers.Queries.GetActiveTrainers
{
    public sealed class GetActiveTrainersQueryHandler : IRequestHandler<GetActiveTrainersQuery, List<TrainerDto>>
    {
        private readonly ITrainerRepository _repo;
        private readonly IMapper _mapper;

        public GetActiveTrainersQueryHandler(ITrainerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TrainerDto>> Handle(GetActiveTrainersQuery request, CancellationToken ct)
        {
            var list = await _repo.GetActiveTrainersAsync(ct);
            return _mapper.Map<List<TrainerDto>>(list);
        }
    }
}

using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Trainers.Dtos;
using WarriorFightClub.Application.Repositories.Trainers;

namespace WarriorFightClub.Application.Features.Trainers.Queries.GetTrainersPaged
{
    public sealed class GetTrainersPagedQueryHandler : IRequestHandler<GetTrainersPagedQuery, PagedResult<TrainerDto>>
    {
        private readonly ITrainerRepository _repo;
        private readonly IMapper _mapper;

        public GetTrainersPagedQueryHandler(ITrainerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PagedResult<TrainerDto>> Handle(GetTrainersPagedQuery request, CancellationToken ct)
        {
            var paged = await _repo.GetPagedAsync(request.Page, request.PageSize, request.IsActive, ct);

            return new PagedResult<TrainerDto>
            {
                Page = paged.Page,
                PageSize = paged.PageSize,
                TotalCount = paged.TotalCount,
                TotalPages = paged.TotalPages,
                Items = _mapper.Map<List<TrainerDto>>(paged.Items)
            };
        }
    }
}

using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Services.Dtos;
using WarriorFightClub.Application.Repositories.Services;

namespace WarriorFightClub.Application.Features.Services.Queries.GetAllServices
{
    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, PagedResult<ServiceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public GetAllServicesQueryHandler(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<PagedResult<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var paged = await _serviceRepository.GetPagedAsync(request.Page,request.PageSize,request.IsActive,cancellationToken);
            return new PagedResult<ServiceDto>
            {
                Page = paged.Page,
                PageSize = paged.PageSize,
                TotalCount = paged.TotalCount,
                TotalPages = paged.TotalPages,
                Items = _mapper.Map<List<ServiceDto>>(paged.Items)
            };
        }
    }
}

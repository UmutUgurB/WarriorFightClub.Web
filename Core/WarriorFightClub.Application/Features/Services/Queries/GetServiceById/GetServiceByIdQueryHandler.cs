using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Features.Services.Dtos;
using WarriorFightClub.Application.Repositories.Services;

namespace WarriorFightClub.Application.Features.Services.Queries.GetServiceById
{
    public sealed class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceDto?>
    {
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(IMapper mapper, IServiceRepository serviceRepository)
        {
            _mapper = mapper;
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceDto?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _serviceRepository.GetByIdAsync(request.Id,tracking:false, cancellationToken);
            return entity is null ? null : _mapper.Map<ServiceDto>(entity); 
        }
    }
}

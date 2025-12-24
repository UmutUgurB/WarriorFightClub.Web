using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Services.Commands.CreateService;
using WarriorFightClub.Application.Features.Services.Commands.UpdateService;
using WarriorFightClub.Application.Features.Services.Queries.GetAllServices;
using WarriorFightClub.Application.Features.Services.Queries.GetServiceById;
using WarriorFightClub.WebApi.Contracts.Services;

namespace WarriorFightClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ServicesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 20 ,bool? isActive =null,CancellationToken cancellationToken = default)
        {
            var value = await _mediator.Send(new GetAllServicesQuery(page, pageSize, isActive),cancellationToken);
            return Ok(value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid Id, CancellationToken ct)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(Id),ct);
            return value is null ? NotFound() : Ok(value);  
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(UpdateServiceRequest updateServiceRequest, Guid id, CancellationToken ct)
        {
            var cmd = _mapper.Map<UpdateServiceCommand>(updateServiceRequest) with { Id = id }; 
            var result = await _mediator.Send(cmd, ct);
            return result ? NoContent() : NotFound();   
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceRequest createServiceRequest,CancellationToken ct)
        {
            var cmd = _mapper.Map<CreateServiceCommand>(createServiceRequest);
            var id = await _mediator.Send(cmd,ct);  
            return Created($"/api/services/{id}", new { id });
        }
    }
}

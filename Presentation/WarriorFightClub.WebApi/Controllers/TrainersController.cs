using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Trainers.Commands.CreateTrainer;
using WarriorFightClub.Application.Features.Trainers.Commands.UpdateTrainer;
using WarriorFightClub.Application.Features.Trainers.Queries.GetActiveTrainers;
using WarriorFightClub.Application.Features.Trainers.Queries.GetTrainerById;
using WarriorFightClub.Application.Features.Trainers.Queries.GetTrainersPaged;
using WarriorFightClub.WebApi.Contracts.Trainers;

namespace WarriorFightClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TrainersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive(CancellationToken ct)
            => Ok(await _mediator.Send(new GetActiveTrainersQuery(), ct));

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] bool? isActive = null, CancellationToken ct = default)
            => Ok(await _mediator.Send(new GetTrainersPagedQuery(page, pageSize, isActive), ct));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new GetTrainerByIdQuery(id), ct);
            return dto is null ? NotFound() : Ok(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrainerRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<CreateTrainerCommand>(request);
            var id = await _mediator.Send(cmd, ct);
            return Created($"/api/trainers/{id}", new { id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTrainerRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<UpdateTrainerCommand>(request) with { Id = id };
            var ok = await _mediator.Send(cmd, ct);
            return ok ? NoContent() : NotFound();
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Abouts.Commands.CreateAbout;
using WarriorFightClub.Application.Features.Abouts.Commands.UpdateAbout;
using WarriorFightClub.Application.Features.Abouts.Queries.GetActiveAbout;
using WarriorFightClub.WebApi.Contracts.Abouts;

namespace WarriorFightClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AboutsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("active")]
        public async Task<IActionResult> GetActive(CancellationToken ct)
        {
            var about = await _mediator.Send(new GetActiveAboutQuery(), ct);
            return about is null ? NotFound() : Ok(about);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAboutRequest request, CancellationToken ct)
        {
            var command = _mapper.Map<CreateAboutCommand>(request);
            var id = await _mediator.Send(command, ct);

            return Created($"/api/abouts/{id}", new { id });
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAboutRequest request, CancellationToken ct)
        {
            var command = _mapper.Map<UpdateAboutCommand>(request) with { Id = id };

            var ok = await _mediator.Send(command, ct);
            return ok ? NoContent() : NotFound();
        }
    }
}

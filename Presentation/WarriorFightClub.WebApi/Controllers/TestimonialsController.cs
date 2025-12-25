using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Testimonials.Commands.CreateTestimonial;
using WarriorFightClub.Application.Features.Testimonials.Commands.UpdateTestimonial;
using WarriorFightClub.Application.Features.Testimonials.Queries.GetAllTestimonials;
using WarriorFightClub.Application.Features.Testimonials.Queries.GetTestimonialById;
using WarriorFightClub.WebApi.Contracts.Testimonials;

namespace WarriorFightClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TestimonialsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("shown")]
        public async Task<IActionResult> GetShown(CancellationToken ct)
            => Ok(await _mediator.Send(new GetShownTestimonialsQuery(), ct));

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] bool? isShown = null, CancellationToken ct = default)
            => Ok(await _mediator.Send(new GetTestimonialsPagedQuery(page, pageSize, isShown), ct));

      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestimonialRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<CreateTestimonialCommand>(request);
            var id = await _mediator.Send(cmd, ct);
            return Created($"/api/testimonials/{id}", new { id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTestimonialRequest request, CancellationToken ct)
        {
            var cmd =  _mapper.Map<UpdateTestimonialCommand>(request) with { Id = id };
            var ok = await _mediator.Send(cmd, ct);
            return ok ? NoContent() : NotFound();
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new GetTestimonialByIdQuery(id), ct);
            return dto is null ? NotFound() : Ok(dto);
        }
    }
}

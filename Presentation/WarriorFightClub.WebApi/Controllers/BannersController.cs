using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Banners.Commands.CreateBanner;
using WarriorFightClub.Application.Features.Banners.Commands.UpdateBanner;
using WarriorFightClub.Application.Features.Banners.Queries.GetAllBanners;
using WarriorFightClub.Application.Features.Banners.Queries.GetBannerById;
using WarriorFightClub.WebApi.Contracts.Banners;

namespace WarriorFightClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BannersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }




        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            var banner = await _mediator.Send(new GetBannerByIdQuery(id), ct);
            return banner is null ? NotFound() : Ok(banner);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBannerRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<CreateBannerCommand>(request);
            var id = await _mediator.Send(cmd, ct);
            return Created($"/api/banners/{id}", new { id });
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBannerRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<UpdateBannerCommand>(request) with { Id = id };
            var ok = await _mediator.Send(cmd, ct);
            return ok ? NoContent() : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] bool? isActive = null, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetAllBannersQuery(page, pageSize, isActive), ct);
            return Ok(result);
        }
    }
}

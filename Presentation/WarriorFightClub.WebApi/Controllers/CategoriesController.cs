using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Categories.Commands.CreateCategory;
using WarriorFightClub.Application.Features.Categories.Commands.DeleteCategory;
using WarriorFightClub.Application.Features.Categories.Commands.UpdateCategory;
using WarriorFightClub.Application.Features.Categories.Queries.GetCategories;
using WarriorFightClub.Application.Features.Categories.Queries.GetCategoriesLookup;
using WarriorFightClub.Application.Features.Categories.Queries.GetCategoryById;
using WarriorFightClub.WebApi.Contracts.Categories;

namespace WarriorFightClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default)
            => Ok(await _mediator.Send(new GetCategoriesPagedQuery(page, pageSize), ct));

        [HttpGet("lookup")]
        public async Task<IActionResult> Lookup(CancellationToken ct)
            => Ok(await _mediator.Send(new GetCategoriesLookupQuery(), ct));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new GetCategoryByIdQuery(id), ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<CreateCategoryCommand>(request);
            var id = await _mediator.Send(cmd, ct);
            return Created($"/api/categories/{id}", new { id });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request, CancellationToken ct)
        {
            var cmd = _mapper.Map<UpdateCategoryCommand>(request) with { Id = id };
            var ok = await _mediator.Send(cmd, ct);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        {
            var ok = await _mediator.Send(new DeleteCategoryCommand(id), ct);
            return ok ? NoContent() : NotFound();
        }
    }
}

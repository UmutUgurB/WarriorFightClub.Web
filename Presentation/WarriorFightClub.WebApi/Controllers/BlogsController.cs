using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Blogs.Commands.CreateBlog;
using WarriorFightClub.Application.Features.Blogs.Commands.DeleteBlog;
using WarriorFightClub.Application.Features.Blogs.Commands.UpdateBlog;
using WarriorFightClub.Application.Features.Blogs.Queries.GetAdminBlogs;
using WarriorFightClub.Application.Features.Blogs.Queries.GetBlogById;
using WarriorFightClub.Application.Features.Blogs.Queries.GetPublicBlogs;
using WarriorFightClub.Domain.Enums;
using WarriorFightClub.WebApi.Contracts.Blogs;

namespace WarriorFightClub.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BlogsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpGet("public")]
    public async Task<IActionResult> GetPublic([FromQuery] int page = 1, [FromQuery] int pageSize = 12, [FromQuery] Guid? categoryId = null, CancellationToken ct = default)
        => Ok(await _mediator.Send(new GetPublicBlogsQuery(page, pageSize, categoryId), ct));


    [HttpGet]
    public async Task<IActionResult> GetAdmin([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? categoryId = null, [FromQuery] BlogStatus? status = null, CancellationToken ct = default)
        => Ok(await _mediator.Send(new GetAdminBlogsQuery(page, pageSize, categoryId, status), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
    {
        var dto = await _mediator.Send(new GetBlogByIdQuery(id), ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBlogRequest request, CancellationToken ct)
    {
        var cmd = _mapper.Map<CreateBlogCommand>(request);
        var id = await _mediator.Send(cmd, ct);
        return Created($"/api/blogs/{id}", new { id });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBlogRequest request, CancellationToken ct)
    {
        var cmd = _mapper.Map<UpdateBlogCommand>(request) with { Id = id };
        var ok = await _mediator.Send(cmd, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
    {
        var ok = await _mediator.Send(new DeleteBlogCommand(id), ct);
        return ok ? NoContent() : NotFound();
    }
}

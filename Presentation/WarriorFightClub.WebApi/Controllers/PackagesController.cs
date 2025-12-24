using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarriorFightClub.Application.Features.Packages.Commands.CreatePackage;
using WarriorFightClub.Application.Features.Packages.Commands.UpdatePackage;
using WarriorFightClub.Application.Features.Packages.Queries.GetAllPackages;
using WarriorFightClub.Application.Features.Packages.Queries.GetPackageById;
using WarriorFightClub.WebApi.Contracts.Packages;

namespace WarriorFightClub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator  _mediator;

        public PackagesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id,CancellationToken ct)
        {
            var package = await _mediator.Send(new GetPackageByIdQuery(id),ct);
            return package is null ? NotFound() : Ok(package);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePackageRequest request, CancellationToken ct)
        {
            var package = _mapper.Map<CreatePackageCommand>(request);
            var id = await _mediator.Send(package, ct);
            return Created($"/api/packages/{id}", new {id});
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id,UpdatePackageRequest request,CancellationToken ct)
        {
            var package = _mapper.Map<UpdatePackageCommand>(request) with { Id = id };
            var value = await _mediator.Send(package, ct);
            return value ? NoContent() : NotFound(); 
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int page =1, int pageSize = 20,bool? isActive = null, CancellationToken ct= default)
        {
            var result = await _mediator.Send(new GetAllPackagesQuery(page, pageSize, isActive), ct);
            return Ok(result);
        }







    }
}

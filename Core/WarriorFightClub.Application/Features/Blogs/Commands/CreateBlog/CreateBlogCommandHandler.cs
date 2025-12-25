using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Blogs;
using WarriorFightClub.Application.Repositories.UnitOfWork;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Application.Features.Blogs.Commands.CreateBlog;

public sealed class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Guid>
{
    private readonly IBlogRepository _repo;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IBlogRepository repo, IUnitOfWork uow, IMapper mapper)
    {
        _repo = repo;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateBlogCommand request, CancellationToken ct)
    {
        var entity = _mapper.Map<Blog>(request);

        await _repo.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}

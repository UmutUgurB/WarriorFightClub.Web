using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Repositories.Blogs;
using WarriorFightClub.Application.Repositories.UnitOfWork;

namespace WarriorFightClub.Application.Features.Blogs.Commands.UpdateBlog;

public sealed class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, bool>
{
    private readonly IBlogRepository _repo;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(IBlogRepository repo, IUnitOfWork uow, IMapper mapper)
    {
        _repo = repo;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken ct)
    {
        var entity = await _repo.GetByIdAsync(request.Id, tracking: true, ct: ct);
        if (entity is null) return false;

        _mapper.Map(request, entity);

        _repo.Update(entity);
        await _uow.SaveChangesAsync(ct);

        return true;
    }
}

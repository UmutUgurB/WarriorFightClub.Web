using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Features.Blogs.Dtos;
using WarriorFightClub.Application.Repositories.Blogs;

namespace WarriorFightClub.Application.Features.Blogs.Queries.GetBlogById;

public sealed class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogDetailDto?>
{
    private readonly IBlogRepository _repo;
    private readonly IMapper _mapper;

    public GetBlogByIdQueryHandler(IBlogRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<BlogDetailDto?> Handle(GetBlogByIdQuery request, CancellationToken ct)
    {
        var blog = await _repo.GetByIdWithCategoryAsync(request.Id, ct);
        return blog is null ? null : _mapper.Map<BlogDetailDto>(blog);
    }
}

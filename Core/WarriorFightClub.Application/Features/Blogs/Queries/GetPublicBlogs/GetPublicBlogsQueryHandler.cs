using AutoMapper;
using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Blogs.Dtos;
using WarriorFightClub.Application.Repositories.Blogs;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Application.Features.Blogs.Queries.GetPublicBlogs
{
    public sealed class GetPublicBlogsQueryHandler : IRequestHandler<GetPublicBlogsQuery, PagedResult<BlogListItemDto>>
    {
        private readonly IBlogRepository _repo;
        private readonly IMapper _mapper;

        public GetPublicBlogsQueryHandler(IBlogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PagedResult<BlogListItemDto>> Handle(GetPublicBlogsQuery request, CancellationToken ct)
        {
            var paged = await _repo.GetPagedWithCategoryAsync(
                request.Page, request.PageSize, request.CategoryId, BlogStatus.Published, ct);

            return new PagedResult<BlogListItemDto>
            {
                Page = paged.Page,
                PageSize = paged.PageSize,
                TotalCount = paged.TotalCount,
                TotalPages = paged.TotalPages,
                Items = _mapper.Map<List<BlogListItemDto>>(paged.Items)
            };
        }
    }
}

using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Blogs.Dtos;

namespace WarriorFightClub.Application.Features.Blogs.Queries.GetPublicBlogs
{
    public sealed record GetPublicBlogsQuery(
    int Page = 1,
    int PageSize = 12,
    Guid? CategoryId = null
) : IRequest<PagedResult<BlogListItemDto>>;
}

using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Blogs.Dtos;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Application.Features.Blogs.Queries.GetAdminBlogs;

public sealed record GetAdminBlogsQuery(
    int Page = 1,
    int PageSize = 20,
    Guid? CategoryId = null,
    BlogStatus? Status = null
) : IRequest<PagedResult<BlogListItemDto>>;

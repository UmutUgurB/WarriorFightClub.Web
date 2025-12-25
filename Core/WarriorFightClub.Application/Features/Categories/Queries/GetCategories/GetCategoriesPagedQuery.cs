using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Categories.Dtos;

namespace WarriorFightClub.Application.Features.Categories.Queries.GetCategories
{
    public sealed record GetCategoriesPagedQuery(int Page = 1, int PageSize = 20)
    : IRequest<PagedResult<CategoryAdminDto>>;
}

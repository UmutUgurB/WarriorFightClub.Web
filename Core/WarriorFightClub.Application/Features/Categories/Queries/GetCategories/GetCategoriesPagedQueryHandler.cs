using MediatR;
using WarriorFightClub.Application.Common.Paging;
using WarriorFightClub.Application.Features.Categories.Dtos;

namespace WarriorFightClub.Application.Features.Categories.Queries.GetCategories
{
    public sealed class GetCategoriesPagedQueryHandler
    : IRequestHandler<GetCategoriesPagedQuery, PagedResult<CategoryAdminDto>>
    {
        private readonly ICategoryRepository _repo;
        public GetCategoriesPagedQueryHandler(ICategoryRepository repo) => _repo = repo;

        public Task<PagedResult<CategoryAdminDto>> Handle(GetCategoriesPagedQuery request, CancellationToken ct)
            => _repo.GetPagedWithBlogCountAsync(request.Page, request.PageSize, ct);
    }
}

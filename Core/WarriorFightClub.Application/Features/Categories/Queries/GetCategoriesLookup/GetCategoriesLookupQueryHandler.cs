using MediatR;
using WarriorFightClub.Application.Features.Categories.Dtos;

namespace WarriorFightClub.Application.Features.Categories.Queries.GetCategoriesLookup
{
    public sealed class GetCategoriesLookupQueryHandler
    : IRequestHandler<GetCategoriesLookupQuery, List<CategoryLookupDto>>
    {
        private readonly ICategoryRepository _repo;
        public GetCategoriesLookupQueryHandler(ICategoryRepository repo) => _repo = repo;

        public Task<List<CategoryLookupDto>> Handle(GetCategoriesLookupQuery request, CancellationToken ct)
            => _repo.GetLookupAsync(ct);
    }
}

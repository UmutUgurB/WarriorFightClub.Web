using MediatR;
using WarriorFightClub.Application.Features.Categories.Dtos;

namespace WarriorFightClub.Application.Features.Categories.Queries.GetCategoryById
{
    public sealed class GetCategoryByIdQueryHandler
    : IRequestHandler<GetCategoryByIdQuery, CategoryDetailDto?>
    {
        private readonly ICategoryRepository _repo;
        public GetCategoryByIdQueryHandler(ICategoryRepository repo) => _repo = repo;

        public Task<CategoryDetailDto?> Handle(GetCategoryByIdQuery request, CancellationToken ct)
            => _repo.GetDetailAsync(request.Id, ct);
    }
}

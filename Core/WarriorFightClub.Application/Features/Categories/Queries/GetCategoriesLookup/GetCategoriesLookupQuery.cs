using MediatR;
using WarriorFightClub.Application.Features.Categories.Dtos;

namespace WarriorFightClub.Application.Features.Categories.Queries.GetCategoriesLookup
{
    public sealed record GetCategoriesLookupQuery : IRequest<List<CategoryLookupDto>>;
}

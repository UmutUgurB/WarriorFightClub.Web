using MediatR;
using WarriorFightClub.Application.Features.Categories.Dtos;

namespace WarriorFightClub.Application.Features.Categories.Queries.GetCategoryById
{
    public sealed record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDetailDto?>;

}

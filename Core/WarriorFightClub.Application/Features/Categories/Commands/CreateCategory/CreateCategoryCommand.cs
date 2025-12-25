using MediatR;

namespace WarriorFightClub.Application.Features.Categories.Commands.CreateCategory
{
    public sealed record CreateCategoryCommand(string Title, string? Description) : IRequest<Guid>;

}

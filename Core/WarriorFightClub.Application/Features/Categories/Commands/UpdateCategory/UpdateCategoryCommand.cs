using MediatR;

namespace WarriorFightClub.Application.Features.Categories.Commands.UpdateCategory
{
    public sealed record UpdateCategoryCommand(Guid Id, string Title, string? Description) : IRequest<bool>;

}

using MediatR;

namespace WarriorFightClub.Application.Features.Categories.Commands.DeleteCategory
{
    public sealed record DeleteCategoryCommand(Guid Id) : IRequest<bool>;

}

using MediatR;

namespace WarriorFightClub.Application.Features.Services.Commands.UpdateService
{
    public sealed record UpdateServiceCommand(
    Guid Id,
    string Title,
    string Description,
    string ImageUrl,
    bool IsActive
) : IRequest<bool>;
}

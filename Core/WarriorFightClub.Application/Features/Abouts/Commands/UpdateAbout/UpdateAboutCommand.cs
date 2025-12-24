using MediatR;

namespace WarriorFightClub.Application.Features.Abouts.Commands.UpdateAbout
{
    public sealed record UpdateAboutCommand(
    Guid Id,
    string Title,
    string SubTitle,
    string Description,
    string ImageUrl,
    bool IsActive
) : IRequest<bool>;
}

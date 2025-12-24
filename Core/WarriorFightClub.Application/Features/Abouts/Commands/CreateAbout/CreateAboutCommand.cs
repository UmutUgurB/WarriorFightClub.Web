using MediatR;

namespace WarriorFightClub.Application.Features.Abouts.Commands.CreateAbout
{
    public sealed record CreateAboutCommand(
    string Title,
    string SubTitle,
    string Description,
    string ImageUrl,
    bool IsActive
) : IRequest<Guid>;
}

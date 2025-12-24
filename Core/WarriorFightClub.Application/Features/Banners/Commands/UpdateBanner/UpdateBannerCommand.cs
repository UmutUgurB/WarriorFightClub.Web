using MediatR;

namespace WarriorFightClub.Application.Features.Banners.Commands.UpdateBanner
{
    public sealed record UpdateBannerCommand(
    Guid Id,
    string Title,
    string SubTitle,
    string Button,
    string ImageUrl,
    bool IsActive
) : IRequest<bool>;
}

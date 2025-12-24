using MediatR;

namespace WarriorFightClub.Application.Features.Banners.Commands.CreateBanner
{
    public sealed record CreateBannerCommand(
    string Title,
    string SubTitle,
    string Button,
    string ImageUrl,
    bool IsActive
) : IRequest<Guid>;
}

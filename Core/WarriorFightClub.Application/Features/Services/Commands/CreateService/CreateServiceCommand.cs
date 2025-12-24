using MediatR;

namespace WarriorFightClub.Application.Features.Services.Commands.CreateService
{
    public sealed record CreateServiceCommand(
     string Title,
     string Description,
     string ImageUrl,
     bool IsActive
 ) : IRequest<Guid>;
}

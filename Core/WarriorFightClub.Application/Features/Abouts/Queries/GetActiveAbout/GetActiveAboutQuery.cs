using MediatR;
using WarriorFightClub.Application.Features.Abouts.Dtos;

namespace WarriorFightClub.Application.Features.Abouts.Queries.GetActiveAbout
{
    public class GetActiveAboutQuery : IRequest<AboutDto?>
    {
    }
}

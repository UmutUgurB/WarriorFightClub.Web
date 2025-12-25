using MediatR;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Application.Features.Blogs.Commands.CreateBlog
{
    public sealed record CreateBlogCommand(
    string Title,
    string Description,
    string ImageUrl,
    Guid CategoryId,
    BlogStatus Status
) : IRequest<Guid>;
}

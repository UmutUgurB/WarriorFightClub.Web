using MediatR;

namespace WarriorFightClub.Application.Features.Blogs.Commands.DeleteBlog
{
    public sealed record DeleteBlogCommand(Guid Id) : IRequest<bool>;
}

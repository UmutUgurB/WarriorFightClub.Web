using MediatR;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Application.Features.Blogs.Commands.UpdateBlog;

public sealed record UpdateBlogCommand(
    Guid Id,
    string Title,
    string Description,
    string ImageUrl,
    Guid CategoryId,
    BlogStatus Status
) : IRequest<bool>;

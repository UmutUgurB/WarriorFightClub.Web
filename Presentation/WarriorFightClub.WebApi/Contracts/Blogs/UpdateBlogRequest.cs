using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.WebApi.Contracts.Blogs
{
    public sealed record UpdateBlogRequest(
    string Title,
    string Description,
    string ImageUrl,
    Guid CategoryId,
    BlogStatus Status
);
}

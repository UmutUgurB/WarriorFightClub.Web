using WarriorFightClub.WebUI.ApiDtos;

namespace WarriorFightClub.WebUI.ViewModels.Blog;

public sealed class BlogIndexVm
{
    public Guid? CategoryId { get; set; }
    public string? CategoryTitle { get; set; }

    public List<CategoryLookupDto> Categories { get; set; } = new();
    public PagedResult<BlogDto> Paged { get; set; } = new();
}

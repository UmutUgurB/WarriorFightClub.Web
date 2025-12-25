namespace WarriorFightClub.Application.Features.Categories.Dtos
{
    public sealed class CategoryLookupDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
    }
}

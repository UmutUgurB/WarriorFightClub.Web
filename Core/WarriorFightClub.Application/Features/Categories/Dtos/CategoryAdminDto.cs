namespace WarriorFightClub.Application.Features.Categories.Dtos
{
    public sealed class CategoryAdminDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public int BlogCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

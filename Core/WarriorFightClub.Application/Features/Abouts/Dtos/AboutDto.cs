namespace WarriorFightClub.Application.Features.Abouts.Dtos
{
    public sealed class AboutDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string SubTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}

namespace WarriorFightClub.Application.Features.Services.Dtos
{
    public sealed record ServiceDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}

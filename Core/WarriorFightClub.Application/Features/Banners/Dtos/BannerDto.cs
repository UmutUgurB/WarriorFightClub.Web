namespace WarriorFightClub.Application.Features.Banners.Dtos
{
    public sealed class BannerDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string SubTitle { get; set; } = default!;
        public string Button { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}

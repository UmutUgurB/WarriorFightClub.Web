namespace WarriorFightClub.WebApi.Contracts.Banners
{
    public sealed class UpdateBannerRequest
    {
        public string Title { get; set; } = default!;
        public string SubTitle { get; set; } = default!;
        public string Button { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}

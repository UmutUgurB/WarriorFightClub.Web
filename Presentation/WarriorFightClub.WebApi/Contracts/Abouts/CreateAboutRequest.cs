namespace WarriorFightClub.WebApi.Contracts.Abouts
{
    public sealed class CreateAboutRequest
    {
        public string Title { get; set; } = default!;
        public string SubTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}

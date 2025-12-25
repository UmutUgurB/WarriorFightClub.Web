namespace WarriorFightClub.WebUI.ApiDtos
{
    public class ServiceDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}

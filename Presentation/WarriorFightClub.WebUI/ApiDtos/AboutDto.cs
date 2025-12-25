namespace WarriorFightClub.WebUI.ApiDtos
{
    public class AboutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

namespace WarriorFightClub.WebUI.ApiDtos
{
    public class PackagesDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Features { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

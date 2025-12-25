namespace WarriorFightClub.WebUI.ApiDtos
{
    public class TrainerDto
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateOnly? BirthDate { get; set; }
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}

namespace WarriorFightClub.Application.Features.Trainers.Dtos
{
    public sealed class TrainerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateOnly? BirthDate { get; set; }
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}

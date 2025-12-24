namespace WarriorFightClub.Application.Features.Testimonials.Dtos
{
    public sealed class TestimonialDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsShown { get; set; } = true;
    }
}

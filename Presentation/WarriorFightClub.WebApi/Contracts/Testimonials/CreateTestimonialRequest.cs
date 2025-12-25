namespace WarriorFightClub.WebApi.Contracts.Testimonials
{
    public sealed class CreateTestimonialRequest
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsShown { get; set; } = true;
    }
}

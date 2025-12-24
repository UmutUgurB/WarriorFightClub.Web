using WarriorFightClub.Domain.Common;

namespace WarriorFightClub.Domain.Entities
{
    public class Testimonial : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool IsShown { get; set; } = true;

    }
}

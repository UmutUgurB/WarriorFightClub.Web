using WarriorFightClub.Domain.Common;

namespace WarriorFightClub.Domain.Entities
{
    public class Service: BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public bool IsActive { get; set; } = true;

    }
}

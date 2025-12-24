using WarriorFightClub.Domain.Common;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Domain.Entities
{
    public class Blog : BaseEntity  
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public Category Category { get; set; } = default!;
        public Guid CategoryId { get; set; } 
        public BlogStatus Status { get; set; } = BlogStatus.Draft;
    }
}

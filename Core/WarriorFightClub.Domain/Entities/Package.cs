using WarriorFightClub.Domain.Common;

namespace WarriorFightClub.Domain.Entities
{
    public class Package : BaseEntity
    {
        public string Title { get; set; }   
        public string Description { get; set; } 
        public string Features { get; set; }    
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

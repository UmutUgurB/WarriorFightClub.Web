using WarriorFightClub.Domain.Common;

namespace WarriorFightClub.Domain.Entities
{
    public class Banner : BaseEntity
    {
        public string Title { get; set; }   
        public string SubTitle { get; set; }
        public string Button { get;set; }
        public string ImageUrl { get; set; }    
        public bool IsActive { get; set; } = true;
    }
}

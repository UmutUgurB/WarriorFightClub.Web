using WarriorFightClub.Domain.Common;

namespace WarriorFightClub.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }   
        public string Description { get; set; } 
        public ICollection<Blog> Blogs { get; set; }   = new List<Blog>();

    }
}

namespace WarriorFightClub.Application.Features.Blogs.Dtos
{
    public sealed class BlogDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
    }
}

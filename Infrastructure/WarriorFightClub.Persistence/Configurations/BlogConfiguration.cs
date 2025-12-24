using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public sealed class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(500);

            builder.HasIndex(x => x.CategoryId);
            builder.HasIndex(x => x.Status);
        }
    }
}

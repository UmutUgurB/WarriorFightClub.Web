using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.HasIndex(x => x.Title).IsUnique(false);
        builder.HasIndex(x => x.CreatedDate);


        builder.HasData(
            new Category
            {
                Id = Guid.Parse("b4a4f2c6-6c55-4c45-8a16-2f3b6c0d1a11"),
                Title = "Fitness",
                Description = "Kuvvet, kondisyon ve genel fitness içerikleri.",
                CreatedDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
            },
            new Category
            {
                Id = Guid.Parse("c9c1a2b0-7a26-4b2f-9b4c-1f0a2d7a3b22"),
                Title = "Dövüş Sporları",
                Description = "Boks, kickboks ve teknik içerikler.",
                CreatedDate = new DateTime(2025, 01, 02, 0, 0, 0, DateTimeKind.Utc)
            },
            new Category
            {
                Id = Guid.Parse("0d9aa7a6-1bd6-46d2-9a8e-87e4d9b9c5b1"),
                Title = "Beslenme",
                Description = "Sağlıklı beslenme ve yaşam tarzı.",
                CreatedDate = new DateTime(2025, 01, 03, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}

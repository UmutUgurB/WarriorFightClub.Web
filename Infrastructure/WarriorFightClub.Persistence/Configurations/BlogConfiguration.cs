using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;
using WarriorFightClub.Domain.Enums;

namespace WarriorFightClub.Persistence.Configurations;

public sealed class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(600);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasIndex(x => x.CreatedDate);
        builder.HasIndex(x => x.CategoryId);
        builder.HasIndex(x => x.Status);


        builder.HasOne(x => x.Category)
            .WithMany(x => x.Blogs)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Blog
            {
                Id = Guid.Parse("7c5d6c0d-6b03-4a90-a82e-3cefb2df0e3a"),
                Title = "Yeni Başlayanlar İçin 5 Temel Hareket",
                Description = "Squat, push-up, row, plank ve deadlift ile temel bir başlangıç planı.",
                ImageUrl = "https://images.unsplash.com/photo-1517836357463-d25dfeac3438?w=1200",
                CategoryId = Guid.Parse("b4a4f2c6-6c55-4c45-8a16-2f3b6c0d1a11"), 
                Status = BlogStatus.Published,
                CreatedDate = new DateTime(2025, 01, 05, 0, 0, 0, DateTimeKind.Utc)
            },
            new Blog
            {
                Id = Guid.Parse("b62f8d9d-4b17-4b2a-90e8-3f13f6a8d3e1"),
                Title = "Kondisyonu Artırmanın 3 Yolu",
                Description = "Interval, tempo koşu ve düzenli takip ile kondisyon geliştirme.",
                ImageUrl = "https://images.unsplash.com/photo-1554284126-aa88f22d8b74?w=1200",
                CategoryId = Guid.Parse("b4a4f2c6-6c55-4c45-8a16-2f3b6c0d1a11"), 
                Status = BlogStatus.Published,
                CreatedDate = new DateTime(2025, 01, 06, 0, 0, 0, DateTimeKind.Utc)
            },
            new Blog
            {
                Id = Guid.Parse("c1d6a6d3-9c2d-4c4f-9a89-8c90a4c5afaa"),
                Title = "Boks’ta Guard ve Mesafe Kontrolü",
                Description = "Doğru guard pozisyonu, mesafe ve zamanlama ipuçları.",
                ImageUrl = "https://images.unsplash.com/photo-1517438984742-1262db08379e?w=1200",
                CategoryId = Guid.Parse("c9c1a2b0-7a26-4b2f-9b4c-1f0a2d7a3b22"), 
                Status = BlogStatus.Published,
                CreatedDate = new DateTime(2025, 01, 07, 0, 0, 0, DateTimeKind.Utc)
            },
            new Blog
            {
                Id = Guid.Parse("f7a11f8a-3a7a-4df8-9b3d-5f4b3a9f1b22"),
                Title = "Kickboks’ta Kombinasyonlar",
                Description = "1-2-low kick ve basic kombinasyon setleri.",
                ImageUrl = "https://images.unsplash.com/photo-1549476464-37392f717541?w=1200",
                CategoryId = Guid.Parse("c9c1a2b0-7a26-4b2f-9b4c-1f0a2d7a3b22"), 
                Status = BlogStatus.Draft,
                CreatedDate = new DateTime(2025, 01, 08, 0, 0, 0, DateTimeKind.Utc)
            },
            new Blog
            {
                Id = Guid.Parse("0f3a2d7a-1b3c-4a61-8f9a-2f3b2f3c7d2f"),
                Title = "Protein Nedir? Ne Zaman Tüketilmeli?",
                Description = "Kas onarımı, toparlanma ve günlük protein hedefi.",
                ImageUrl = "https://images.unsplash.com/photo-1540189549336-e6e99c3679fe?w=1200",
                CategoryId = Guid.Parse("0d9aa7a6-1bd6-46d2-9a8e-87e4d9b9c5b1"), 
                Status = BlogStatus.Published,
                CreatedDate = new DateTime(2025, 01, 09, 0, 0, 0, DateTimeKind.Utc)
            },
            new Blog
            {
                Id = Guid.Parse("2f3b2f3c-7d2f-4a61-8f9a-0f3a2d7a1b3c"),
                Title = "Yağ Yakımı İçin Basit Beslenme Prensipleri",
                Description = "Kalori dengesi, protein önceliği ve sürdürülebilir alışkanlıklar.",
                ImageUrl = "https://images.unsplash.com/photo-1490645935967-10de6ba17061?w=1200",
                CategoryId = Guid.Parse("0d9aa7a6-1bd6-46d2-9a8e-87e4d9b9c5b1"), 
                Status = BlogStatus.Draft,
                CreatedDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}

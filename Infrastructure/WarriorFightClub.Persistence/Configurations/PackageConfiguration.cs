using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public sealed class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Packages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Features)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => x.IsActive);
            builder.HasIndex(x => x.CreatedDate);


            builder.HasData(
                new Package
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
                    Title = "Başlangıç Paketi",
                    Description = "Spora yeni başlayanlar için temel program ve takip.",
                    Features = "Haftada 3 gün program; Ölçüm takibi; Salon kullanımı",
                    ImageUrl = "https://www.macfit.com/wp-content/uploads/2022/11/fitness-salonlari-1024x683.jpg",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new Package
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"),
                    Title = "Pro Paket",
                    Description = "Gelişmiş program + daha sık takip ve danışmanlık.",
                    Features = "Haftada 5 gün program; Beslenme önerisi; Aylık ölçüm",
                    ImageUrl = "https://www.sportsuniverse.com.tr/wp-content/uploads/2020/06/905A8B53-D0A3-45E3-8CDF-3AA4A5B9C24F.jpeg",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 02, 0, 0, 0, DateTimeKind.Utc)
                },
                new Package
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"),
                    Title = "PT (Bire Bir) Paketi",
                    Description = "Antrenör ile bire bir çalışma ve maksimum verim.",
                    Features = "Bire bir seans; Program planlama; Haftalık takip",
                    ImageUrl = "https://media.istockphoto.com/id/2075354173/tr/foto%C4%9Fraf/fitness-couple-is-doing-kettlebell-twist-in-a-gym-togehter.jpg?s=612x612&w=0&k=20&c=GibU8-6Ydswl3qjVPJ8FIx8c7_15aYf-rw0wg85M_oo=",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 03, 0, 0, 0, DateTimeKind.Utc)
                },
                new Package
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"),
                    Title = "Kurumsal Paket",
                    Description = "Şirket çalışanlarına özel toplu üyelik ve avantajlar.",
                    Features = "Toplu üyelik indirimi; Kurumsal raporlama; Esnek plan",
                    ImageUrl = "https://nutrade.com.tr/cdn/shop/articles/Fitness-ile-Ilgili-Bilinmesi-Gerekenler.jpg?v=1701794880",
                    IsActive = false,
                    CreatedDate = new DateTime(2025, 01, 04, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}

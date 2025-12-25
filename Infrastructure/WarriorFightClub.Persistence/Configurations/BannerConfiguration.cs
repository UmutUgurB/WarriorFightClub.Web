using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable("Banners");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.SubTitle)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Button)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => x.IsActive);

            // --- Seed Data ---
            builder.HasData(
                new Banner
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), // Geçerli Format
                    Title = "Sınırlarını Zorla",
                    SubTitle = "Profesyonel eğitmenlerle gücünü keşfet.",
                    Button = "Hemen Katıl",
                    ImageUrl = "https://olimpiaspormerkezi.com/spor-salonuna-gitmenin-faydalari/",
                    IsActive = true,
                    CreatedDate = new DateTime(2023, 10, 1)
                },
                new Banner
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Title = "Dövüş Sanatlarında Ustalık",
                    SubTitle = "Warrior Fight Club ile disiplin ve teknik bir arada.",
                    Button = "Dersleri İncele",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRoOY1IODlwhJS68nmqU56bDek_SqxElruCwQ&s",
                    IsActive = true,
                    CreatedDate = new DateTime(2023, 10, 1)
                },
                new Banner
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Title = "Şampiyonların Tercihi",
                    SubTitle = "En modern ekipmanlarla antrenman yapmaya başla.",
                    Button = "Üye Ol",
                    ImageUrl = "https://img.freepik.com/free-photo/strong-man-training-gym_1303-23478.jpg?semt=ais_hybrid&w=740&q=80",
                    IsActive = true,
                    CreatedDate = new DateTime(2023, 10, 1)
                }
            );
        }
    }
}
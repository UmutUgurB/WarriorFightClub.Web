using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => x.IsActive);
            builder.HasIndex(x => x.CreatedDate);

            // ✅ Seed Data
            builder.HasData(
                new Service
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
                    Title = "Kişisel Antrenman",
                    Description = "Hedeflerinize uygun, bire bir antrenman planı ve takip.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/5ede457a2188e55de5de09a7/1591889835496-GPGGP2ZIRL0V41HKKOGH/The+Benefits+Of+Personal+Training+At+Home.jpg",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new Service
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),
                    Title = "Fonksiyonel Antrenman",
                    Description = "Dayanıklılık, kuvvet ve hareket kabiliyetini artıran programlar.",
                    ImageUrl = "https://www.skechers.com.tr/blog/wp-content/uploads/2023/03/fitnes.jpg",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 02, 0, 0, 0, DateTimeKind.Utc)
                },
                new Service
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"),
                    Title = "Boks & Kickboks",
                    Description = "Teknik gelişim + kondisyon odaklı dövüş sporları antrenmanları.",
                    ImageUrl = "https://img2.storyblok.com/690x690/filters:focal(null):format(png)/f/115220/1100x1100/f1f74de82a/mitt_work.png",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 03, 0, 0, 0, DateTimeKind.Utc)
                },
                new Service
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
                    Title = "Online Koçluk",
                    Description = "Uzaktan program, beslenme önerileri ve düzenli kontrol.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqAiIpZh7QAtitPhv_6kLZPftvIU1_G3lbRg&s",
                    IsActive = false,
                    CreatedDate = new DateTime(2025, 01, 04, 0, 0, 0, DateTimeKind.Utc)
                },
                new Service
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
                    Title = "Yüzme Dersleri",
                    Description = "Uzaktan program, beslenme önerileri ve düzenli kontrol.",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/60b770454e1e5542857bb262/1694527499153-QZ4BDA3SIN9L5AICSB34/ukactive-Swimming-lessons-lost-in-lockdown.jpg",
                    IsActive = false,
                    CreatedDate = new DateTime(2025, 01, 04, 0, 0, 0, DateTimeKind.Utc)
                }
                ,new Service
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
                    Title = "Pilates",
                    Description = "Uzaktan program, beslenme önerileri ve düzenli kontrol.",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxl96SR5NMdDrgO2O2wkRFmlfUPrYTobwBzA&s",
                    IsActive = false,
                    CreatedDate = new DateTime(2025, 01, 04, 0, 0, 0, DateTimeKind.Utc)
                }

                
            );
        }
    }
}
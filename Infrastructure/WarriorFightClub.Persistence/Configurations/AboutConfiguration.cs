using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.SubTitle)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);


            builder.HasIndex(x => x.IsActive);


            builder.HasIndex(x => x.IsActive)
                   .IsUnique()
                   .HasFilter("[IsActive] = 1");
            builder.HasData(new About
            {
                Id = Guid.Parse("A1B2C3D4-E5F6-4A5B-8C9D-0E1F2A3B4C5D"), 
                Title = "Warrior Fight Club",
                SubTitle = "Sınırlarını Zorlamaya Hazır Mısın?",
                Description = "Warrior Fight Club, modern dövüş sanatları tekniklerini profesyonel eğitmenler eşliğinde sunan, disiplin ve gücü odak noktasına alan bir spor salonudur. Burada sadece vücudunuzu değil, iradenizi de eğitiyoruz.",
                ImageUrl = "https://lh5.googleusercontent.com/proxy/stFBPjVPFdJzQCb1Rbb2XU4MlsoM522iD7cVRBVpH-8Kj7VcmKxBMK03tHVqPifTmqL64p62CiJMduxyH3aEtX06Kp_9MppCXE3uUK2dcDVNRlvy-EsPRp9i62bmhYIJzcbVd24",
                IsActive = true
            });
        }
    }
}

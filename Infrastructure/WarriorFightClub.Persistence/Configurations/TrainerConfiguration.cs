using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public sealed class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.ToTable("Trainers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);


            var dateOnlyConverter = new ValueConverter<DateOnly?, DateTime?>(
                d => d.HasValue ? d.Value.ToDateTime(TimeOnly.MinValue) : null,
                d => d.HasValue ? DateOnly.FromDateTime(d.Value) : null
            );

            builder.Property(x => x.BirthDate)
                .HasConversion(dateOnlyConverter)
                .HasColumnType("date");

            builder.HasIndex(x => x.IsActive);
            builder.HasIndex(x => x.CreatedDate);


            builder.HasData(
                new Trainer
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc1"),
                    Name = "Ahmet",
                    Surname = "Yılmaz",
                    Description = "Fonksiyonel antrenman ve kuvvet geliştirme uzmanı.",
                    BirthDate = new DateOnly(1992, 06, 15),
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/mh-trainer-2-1533576998.png?resize=640:*",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new Trainer
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc2"),
                    Name = "Elif",
                    Surname = "Demir",
                    Description = "Pilates, mobilite ve postür düzeltme odaklı çalışmalar.",
                    BirthDate = new DateOnly(1995, 02, 10),
                    ImageUrl = "https://www.shutterstock.com/shutterstock/photos/1583397034/display_1500/stock-photo-young-female-fitness-personal-trainer-with-notepad-standing-in-the-gym-with-thumb-up-1583397034.jpg",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 02, 0, 0, 0, DateTimeKind.Utc)
                },
                new Trainer
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc3"),
                    Name = "Mert",
                    Surname = "Kaya",
                    Description = "Boks ve kickboks antrenörü, kondisyon odaklı programlar.",
                    BirthDate = new DateOnly(1990, 11, 03),
                    ImageUrl = "https://images.ctfassets.net/qw8ps43tg2ux/1LPfI8kPATAzojZMBalhli/7dbdddba786444110a762b75977a8fd8/how-it-works-issa-certified-personal-trainer.webp?fm=webp&w=1440&q=75",
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 01, 03, 0, 0, 0, DateTimeKind.Utc)
                },
                new Trainer
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc4"),
                    Name = "Zeynep",
                    Surname = "Aydın",
                    Description = "Yeni başlayanlar için temel programlar ve beslenme danışmanlığı.",
                    BirthDate = null,
                    ImageUrl = "https://ici.net.au/blog/wp-content/uploads/2019/04/BecomePersonalTrainer-1024x683.jpg",
                    IsActive = false,
                    CreatedDate = new DateTime(2025, 01, 04, 0, 0, 0, DateTimeKind.Utc)
                },
                new Trainer
                {
                    Id = Guid.Parse("cccccccc-cccc-cccc-cccc-ccccccccccc4"),
                    Name = "Akif",
                    Surname = "Aydın",
                    Description = "Uzmanlar için temel programlar ve beslenme danışmanlığı.",
                    BirthDate = null,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcStzFOrI0wwFupHIFL7p0lU3Brr9MaQv70MrQ&s",
                    IsActive = false,
                    CreatedDate = new DateTime(2025, 01, 04, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
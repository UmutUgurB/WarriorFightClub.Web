using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public sealed class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.IsShown)
                .HasDefaultValue(true);

            builder.HasIndex(x => x.IsShown);
            builder.HasIndex(x => x.CreatedDate);

            builder.HasData(
                new Testimonial
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "Harika bir salon!",
                    Description = "Antrenörler çok ilgili, ortam tertemiz. Kısa sürede farkı gördüm.",
                    IsShown = true,
                    CreatedDate = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                },
                new Testimonial
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Title = "Disiplin ve motivasyon",
                    Description = "Programlar net, hedef odaklı. Motivasyonum çok arttı.",
                    IsShown = true,
                    CreatedDate = new DateTime(2025, 01, 05, 0, 0, 0, DateTimeKind.Utc)
                },
                new Testimonial
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Title = "Yeni başlayanlar için ideal",
                    Description = "İlk kez başladım, her adımda destek oldular. Kesinlikle tavsiye ederim.",
                    IsShown = false, // admin panelde dursun ama sitede görünmesin
                    CreatedDate = new DateTime(2025, 01, 10, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}

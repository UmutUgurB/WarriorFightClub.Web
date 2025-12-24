using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarriorFightClub.Domain.Entities;

namespace WarriorFightClub.Persistence.Configurations
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Packages");

            builder.HasKey(x => x.Id);  

            builder.Property(x=>x.Title).IsRequired();  
            builder.Property(x=> x.Description).IsRequired();   
            builder.Property(x=>x.Features).IsRequired();

            builder.HasIndex(x => x.Title);
        }
    }
}

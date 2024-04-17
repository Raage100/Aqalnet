using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Propertys.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class LandConfigurations : IEntityTypeConfiguration<Land>
{
    public void Configure(EntityTypeBuilder<Land> builder)
    {
        builder.ToTable("lands");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        //builder.HasOne<Property>()
        // .WithOne()
        // .HasForeignKey<Land>(a => a.PropertyId);
        builder
            .HasOne(a => a.Property) // Navigation property
            .WithOne(p => p.Land) // Corresponding navigation property in Property
            .HasForeignKey<Land>(a => a.PropertyId); // Foreign key

        builder.ComplexProperty(
            x => x.Latitude,
            Latitude =>
            {
                Latitude.Property(x => x.Value).HasColumnName("latitude").HasPrecision(10, 7);
            }
        );

        builder.ComplexProperty(
            x => x.Longitude,
            Longitude =>
            {
                Longitude.Property(x => x.Value).HasColumnName("longitude").HasPrecision(10, 7);
            }
        );
    }
}

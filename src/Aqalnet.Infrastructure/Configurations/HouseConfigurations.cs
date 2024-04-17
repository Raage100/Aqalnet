using Aqalnet.Domain.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class HouseConfigurations : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.ToTable("houses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder
            .HasOne(a => a.Property) // Navigation property
            .WithOne(p => p.House) // Corresponding navigation property in Property
            .HasForeignKey<House>(a => a.PropertyId); // Foreign key

        builder.ComplexProperty(
            x => x.HasGarage,
            hasGarage =>
            {
                hasGarage.Property(x => x.Value).HasColumnName("has_garage");
            }
        );

        builder.ComplexProperty(
            x => x.HasParking,
            hasParking =>
            {
                hasParking.Property(x => x.Value).HasColumnName("has_parking");
            }
        );

        builder.ComplexProperty(
            x => x.NumberOfRooms,
            numberOfRooms =>
            {
                numberOfRooms.Property(x => x.Value).HasColumnName("number_of_rooms");
            }
        );

        builder.ComplexProperty(
            x => x.NumberOfFloors,
            numberOfFloors =>
            {
                numberOfFloors.Property(x => x.Value).HasColumnName("number_of_floors");
            }
        );

        builder.ComplexProperty(
            x => x.NumberOfToilets,
            numberOfToilets =>
            {
                numberOfToilets.Property(x => x.Value).HasColumnName("number_of_toilets");
            }
        );

        builder.ComplexProperty(
            x => x.YearBuilt,
            yearBuilt =>
            {
                yearBuilt.Property(x => x.Value).HasColumnName("year_built");
            }
        );
    }
}

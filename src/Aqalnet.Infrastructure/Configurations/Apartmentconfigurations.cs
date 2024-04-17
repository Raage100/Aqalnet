using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Propertys.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class Apartmentconfigurations : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("apartments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder
            .HasOne(a => a.Property) // Navigation property
            .WithOne(p => p.Apartment) // Corresponding navigation property in Property
            .HasForeignKey<Apartment>(a => a.PropertyId); // Foreign key

        builder.ComplexProperty(
            x => x.HasParking,
            hasParking =>
            {
                hasParking.Property(x => x.Value).HasColumnName("has_parking");
            }
        );

        builder.ComplexProperty(
            x => x.HasBalcony,
            hasBalcony =>
            {
                hasBalcony.Property(x => x.Value).HasColumnName("has_balcony");
            }
        );

        builder.ComplexProperty(
            x => x.Floor,
            floor =>
            {
                floor.Property(x => x.Value).HasColumnName("floor");
            }
        );

        builder.ComplexProperty(
            x => x.HasElevator,
            hasElevator =>
            {
                hasElevator.Property(x => x.Value).HasColumnName("has_elevator");
            }
        );

        builder.ComplexProperty(
            x => x.YearBuilt,
            yearBuilt =>
            {
                yearBuilt.Property(x => x.Value).HasColumnName("year_built");
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
            x => x.NumberOfToilets,
            numberOfToilets =>
            {
                numberOfToilets.Property(x => x.Value).HasColumnName("number_of_toilets");
            }
        );
    }
}

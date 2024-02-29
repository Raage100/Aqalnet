using Aqalnet.Domain.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class Apartmentconfigurations : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("Apartments");
        builder.HasKey(x =>  new {x.Id, x.PropertyId});
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.LivingArea).HasPrecision(18, 2);
        builder.Property(x => x.PricePerSquareMeter).HasPrecision(18, 2);
    }
}

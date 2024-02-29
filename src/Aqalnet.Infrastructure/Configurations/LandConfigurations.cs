using Aqalnet.Domain.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class LandConfigurations : IEntityTypeConfiguration<Land>
{
    public void Configure(EntityTypeBuilder<Land> builder)
    {
        builder.ToTable("Lands");
        builder.HasKey(x => new { x.Id, x.PropertyId });
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Area).HasPrecision(18, 2);
        builder.Property(x => x.PricePerSquareMeter).HasPrecision(18, 2);
    }
}

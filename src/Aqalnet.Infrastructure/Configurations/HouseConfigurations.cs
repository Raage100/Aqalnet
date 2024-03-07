using Aqalnet.Domain.Propertys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class HouseConfigurations : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.ToTable("Houses");
        builder.HasKey(x => new { x.Id, x.PropertyId });

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.PlotArea).HasPrecision(18, 2);
        builder.Property(x => x.BuildingArea).HasPrecision(18, 2);
        builder.Property(x => x.PricePerSquareMeter).HasPrecision(18, 2);
    }
}

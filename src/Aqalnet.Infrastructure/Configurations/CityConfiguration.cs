using Aqalnet.Domain.Cities;
using Aqalnet.Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Name = Aqalnet.Domain.Cities.Name;

namespace Aqalnet.Infrastructure.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("cities");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.ComplexProperty(
            x => x.Name,
            name =>
            {
                name.Property(x => x.Value).HasColumnName("name");
            }
        );
        builder.HasOne<Country>().WithMany().HasForeignKey(x => x.CountryId);
    }
}

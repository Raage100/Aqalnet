using Aqalnet.Domain.Cities;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Propertys.ValueObjects;
using Aqalnet.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable("properties");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.ComplexProperty(
            x => x.IsPublished,
            isPublished =>
            {
                isPublished.Property(x => x.Value).HasColumnName("is_published").IsRequired();
            }
        );

        builder.ComplexProperty(
            x => x.DatePublished,
            datePublished =>
            {
                datePublished.Property(x => x.Value).HasColumnName("date_published").IsRequired();
            }
        );

        builder.ComplexProperty(
            x => x.Address,
            address =>
            {
                address.Property(x => x.Street).HasColumnName("street").IsRequired();
                address.Property(x => x.StreetNumber).HasColumnName("street_number").IsRequired();
            }
        );

        builder.ComplexProperty(
            x => x.Price,
            price =>
            {
                price
                    .Property(x => x.Amount)
                    .HasColumnName("price")
                    .HasPrecision(18, 2)
                    .IsRequired();
                price
                    .Property(x => x.Currency)
                    .HasColumnName("currency")
                    .HasConversion(c => c.Code, cdoe => Currency.FromCode(cdoe));
            }
        );

        builder.ComplexProperty(
            x => x.About,
            about =>
            {
                about.Property(x => x.Value).HasColumnName("about").IsRequired();
            }
        );

        builder.ComplexProperty(
            x => x.PricePerSquareMeter,
            pricePerSquareMeter =>
            {
                pricePerSquareMeter
                    .Property(x => x.Value)
                    .HasColumnName("price_per_square_meter")
                    .HasPrecision(18, 2);
            }
        );

        builder.ComplexProperty(
            x => x.Area,
            area =>
            {
                area.Property(x => x.Value).HasColumnName("area").HasPrecision(18, 2);
            }
        );

        builder.HasMany<Image>("_images").WithOne().HasForeignKey(img => img.PropertyId);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId).IsRequired();
        builder.HasOne<City>().WithMany().HasForeignKey(e => e.CityId).IsRequired();
    }
}

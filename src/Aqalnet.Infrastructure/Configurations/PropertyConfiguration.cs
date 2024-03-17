using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable("Properties");
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Price).HasPrecision(18, 2);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.OwnsOne(
            x => x.Address,
            a =>
            {
                a.Property(x => x.Street).HasColumnName("street").IsRequired();
                a.Property(x => x.City).HasColumnName("city").IsRequired();
            }
        );

        builder.HasOne(x => x.House).WithOne().HasForeignKey<House>(x => x.Id).IsRequired(false);

        builder
            .HasOne(x => x.Apartment)
            .WithOne()
            .HasForeignKey<Apartment>(x => x.Id)
            .IsRequired(false);

        builder.HasOne(x => x.Land).WithOne().HasForeignKey<Land>(x => x.Id).IsRequired(false);

        builder.HasMany<Image>("_images").WithOne().HasForeignKey(img => img.PropertyId);

        builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId).IsRequired();

        builder.HasOne<Company>().WithMany().HasForeignKey(e => e.CompanyId).IsRequired(false);
    }
}

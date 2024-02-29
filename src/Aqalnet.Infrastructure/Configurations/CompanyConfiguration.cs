using Aqalnet.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.OwnsOne(
            x => x.Address,
            a =>
            {
                a.Property(x => x.Street).HasColumnName("Street").IsRequired();
                a.Property(x => x.City).HasColumnName("City").IsRequired();
            }
        );

        builder.OwnsOne(
            x => x.Logo,
            a =>
            {
                a.Property(x => x.Url).HasColumnName("LogoUrl").IsRequired();
            }
        );
    }
}

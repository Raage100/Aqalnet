using Aqalnet.Domain.Propertys;
using Aqalnet.Domain.Propertys.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class ImageConfigurations : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("images");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.ComplexProperty(
            x => x.Url,
            url =>
            {
                url.Property(x => x.Value).HasColumnName("url");
            }
        );

        builder.ComplexProperty(
            x => x.Alt,
            alt =>
            {
                alt.Property(x => x.Value).HasColumnName("alt");
            }
        );

        builder.ComplexProperty(
            x => x.Title,
            title =>
            {
                title.Property(x => x.Value).HasColumnName("title");
            }
        );

        builder.ComplexProperty(
            x => x.Description,
            description =>
            {
                description.Property(x => x.Value).HasColumnName("description");
            }
        );
    }
}

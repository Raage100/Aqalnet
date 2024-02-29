using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.HasOne<Company>().WithMany().HasForeignKey(e => e.CompanyId).IsRequired(false);

        builder.OwnsOne(
            x => x.ProfilePicture,
            i =>
            {
                i.Property(x => x.Url).HasColumnName("ProfilePictureUrl").IsRequired();
            }
        );
    }
}

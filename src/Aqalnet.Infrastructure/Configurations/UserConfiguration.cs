using Aqalnet.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aqalnet.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.ComplexProperty(
            x => x.FirstName,
            firstName =>
            {
                firstName.Property(x => x.Value).HasColumnName("first_name");
            }
        );

        builder.ComplexProperty(
            x => x.LastName,
            lastName =>
            {
                lastName.Property(x => x.Value).HasColumnName("last_name");
            }
        );

        builder.ComplexProperty(
            x => x.Email,
            email =>
            {
                email.Property(x => x.Value).HasColumnName("email");
            }
        );

        builder.ComplexProperty(
            x => x.MobileNumber,
            mobileNumber =>
            {
                mobileNumber.Property(x => x.Value).HasColumnName("mobile_number");
            }
        );

        builder.ComplexProperty(
            x => x.Oid,
            oid =>
            {
                oid.Property(x => x.Value).HasColumnName("oid");
            }
        );

        builder.ComplexProperty(
            x => x.CreatedAt,
            createdAt =>
            {
                createdAt.Property(x => x.Value).HasColumnName("created_at");
            }
        );

        builder.ComplexProperty(
            x => x.ProfilePicture,
            profilePicture =>
            {
                profilePicture
                    .Property(x => x.Value)
                    .HasColumnName("profile_picture_url")
                    .IsRequired(false);
            }
        );
    }
}

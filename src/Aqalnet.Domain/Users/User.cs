using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Users.ValueObjects;

namespace Aqalnet.Domain.Users;

public sealed class User : AggregateRoot
{
    private User(
        Guid id,
        FirstName firstName,
        LastName lastName,
        Email email,
        MobileNumber mobileNumber,
        CreatedAt createdAt,
        Oid oid,
        ProfilePicture? profilePicture = null
    )
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        MobileNumber = mobileNumber;
        CreatedAt = createdAt;
        Oid = oid;
        ProfilePicture = profilePicture;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    public MobileNumber MobileNumber { get; private set; }

    public ProfilePicture ProfilePicture { get; private set; }

    public Oid Oid { get; private set; }

    public CreatedAt CreatedAt { get; private set; }

    public static User Create(
        FirstName firstName,
        LastName lastName,
        Email email,
        MobileNumber mobileNumber,
        CreatedAt createdAt,
        Oid oid,
        ProfilePicture profilePicture
    )
    {
        var user = new User(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            mobileNumber,
            createdAt,
            oid,
            profilePicture
        );

        return user;
    }

    public User() { }
}

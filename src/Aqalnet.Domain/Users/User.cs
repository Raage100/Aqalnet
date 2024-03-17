using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Users;

public sealed class User : AggregateRoot
{
    private User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string mobileNumber,
        DateOnly createdAt,
        ProfilePicture? profilePicture = null,
        Guid? companyId = null
    )
        : base(id)
    {
        CompanyId = companyId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        MobileNumber = mobileNumber;
        ProfilePicture = profilePicture;
        CompanyId = companyId;
        CreatedAt = createdAt;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public string MobileNumber { get; private set; }

    public ProfilePicture? ProfilePicture { get; private set; }

    public Role Role { get; private set; }
    public bool IsActive { get; private set; }

    public DateOnly CreatedAt { get; private set; }
    public DateOnly? UpdatedAt { get; private set; }

    public Guid? CompanyId { get; private set; } // This is a reference to another aggregate root company

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string mobileNumber,
        ProfilePicture profilePicture,
        DateOnly createdAt
    )
    {
        var user = new User(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            mobileNumber,
            createdAt,
            profilePicture
        );

        user.Role = user.CompanyId == null ? Role.Regular : Role.Agent;

        return user;
    }

    public static User CreateAdminUser(
        string firstName,
        string lastName,
        string email,
        string mobileNumber,
        DateOnly createdat,
        ProfilePicture profilePicture,
        Guid companyId
    )
    {
        var user = new User(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            mobileNumber,
            createdat,
            profilePicture,
            companyId
        );

        user.Role = Role.Agent;

        return user;
    }

    public User() { }
}

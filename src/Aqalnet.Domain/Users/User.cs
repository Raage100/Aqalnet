using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Users;

public sealed class User : AggregateRoot
{
    private User(Guid id, string firstName, string lastName, string email, string mobileNumber)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        MobileNumber = mobileNumber;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public string MobileNumber { get; private set; }

    public ProfilePicture ProfilePicture { get; private set; }

    public Role Role { get; private set; }
    public bool IsActive { get; private set; }

    public DateOnly CreatedAt { get; private set; }
    public DateOnly? UpdatedAt { get; private set; }

    public Guid? CompanyId { get; private set; } // This is a reference to another aggregate root company

    public static User Create(string firstName, string lastName, string email, string mobileNumber)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email, mobileNumber);
        user.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
        user.Role = Role.Regular;

        return user;
    }

    public void AssociateWithCompany(Guid companyId)
    {
        CompanyId = companyId;
        Role = Role.Admin;
    }

    public User() { }
}

namespace Aqalnet.Application.Users.GetUserById;

public record UserResponse
{
    public UserResponse(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string mobileNumber,
        string oid,
        DateOnly createdAt
    )
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        MobileNumber = mobileNumber;
        Oid = oid;
        CreatedAt = createdAt;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Oid { get; set; }

    public DateOnly CreatedAt { get; set; }
}

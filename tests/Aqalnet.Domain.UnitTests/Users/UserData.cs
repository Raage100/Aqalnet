using Aqalnet.Domain.Users.ValueObjects;

namespace Aqalnet.Domain.UnitTests.Users;

internal static class UserData
{
    public static readonly FirstName FirstName = new("First");
    public static readonly LastName LastName = new("last");
    public static readonly Email Email = new("Email@gmail.com");
    public static readonly MobileNumber MobileNumber = new("1234567890");
    public static readonly Oid oid = new("312313213");
    public static readonly ProfilePicture ProfilePicture = new("profileurl");
    public static readonly CreatedAt CreatedAt = new(DateOnly.FromDateTime(DateTime.UtcNow.Date));
}

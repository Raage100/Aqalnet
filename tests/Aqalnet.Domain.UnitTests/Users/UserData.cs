using Aqalnet.Domain.Users;

namespace Aqalnet.Domain.UnitTests.Users;

internal static class UserData
{
    public static readonly string FirstName = "First";
    public static readonly string LastName = "Last";
    public static readonly string Email = "test@test.com";
    public static readonly string MobileNumber = "1234567890";
    public static readonly ProfilePicture ProfilePicture = new("profileurl");
}

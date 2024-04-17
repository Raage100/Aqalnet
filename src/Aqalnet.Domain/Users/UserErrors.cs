using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Users;

public static class UserErrors
{
    public static Error NotFound => new("User.NotFound", "User not found");
    public static Error NotCreated => new("User.NotCreated", "User not created");
}

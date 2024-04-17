namespace Aqalnet.Api.Controllers.Users;

public record RegisterUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string MobileNumber,
    string? ProfilePicture,
    string Oid
);

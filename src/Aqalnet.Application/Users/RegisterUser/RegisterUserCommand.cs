using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string MobileNumber,
    string? ProfilePicture,
    string Oid
) : ICommand<Guid>;

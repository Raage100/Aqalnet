using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Users.GetUserById;

public sealed record GetUserByIdQuery(Guid Id) : IQuery<UserResponse>;

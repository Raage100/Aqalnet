using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Users;

namespace Aqalnet.Application.Users.GetUserById;

internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponse>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound);
        }

        return Result.Success(
            new UserResponse(
                user.Id,
                user.FirstName.Value,
                user.LastName.Value,
                user.Email.Value,
                user.MobileNumber.Value,
                user.Oid.Value,
                user.CreatedAt.Value
            )
        );
    }
}

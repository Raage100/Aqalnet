using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Users;
using Aqalnet.Domain.Users.ValueObjects;

namespace Aqalnet.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken
    )
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email),
            new MobileNumber(request.MobileNumber),
            new CreatedAt(DateOnly.FromDateTime(DateTime.UtcNow.Date)),
            new Oid(request.Oid),
            new ProfilePicture(request.ProfilePicture)
        );
        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}

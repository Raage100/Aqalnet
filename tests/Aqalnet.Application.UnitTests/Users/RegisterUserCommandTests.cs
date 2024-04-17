using Aqalnet.Application.Users.RegisterUser;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Users;
using FluentAssertions;
using NSubstitute;

namespace Aqalnet.Application.UnitTests.Users;

public class RegisterUserCommandTests
{
    private static readonly RegisterUserCommand Command =
        new("first", "last", "first@email.com", "123442322", "url", "78217287");

    private readonly RegisterUserCommandHandler _handler;
    private readonly IUserRepository _userRepositoryMock;
    private readonly IUnitOfWork _unitOfWorkMock;

    public RegisterUserCommandTests()
    {
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        _handler = new RegisterUserCommandHandler(_userRepositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_Should_CallRepository()
    {
        // Ac
        Result<Guid> result = await _handler.Handle(Command, default);

        // Assert
        _userRepositoryMock.Received(1).Add(Arg.Is<User>(u => u.Id == result.Value));
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_CallUnitOfWork()
    {
        // Act
        Result<Guid> result = await _handler.Handle(Command, default);

        // Assert
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }


}

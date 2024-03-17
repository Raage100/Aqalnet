using Aqalnet.Application.Abstractions.Clock;
using Aqalnet.Application.Companies;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace Aqalnet.Application.UnitTests.Companies;

public class RegisterAgentTests
{
    public static readonly RegisterAgentCommand Command =
        new(Guid.NewGuid(), "First", "Last", "test@gemail.com", "1234567890", "title", new("url"));

    private readonly RegisterAgentCommandHandler _handler;

    private readonly ICompanyRepository _companyRepositoryMock;
    private readonly IUserRepository _userRepositoryMock;
    private IUnitOfWork _unitOfWorkMock;
    private IDateTimeProvider _dateTimeProviderMock;

    public RegisterAgentTests()
    {
        _companyRepositoryMock = Substitute.For<ICompanyRepository>();
        _userRepositoryMock = Substitute.For<IUserRepository>();
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _dateTimeProviderMock = Substitute.For<IDateTimeProvider>();
        _dateTimeProviderMock.UtcNow.Returns(DateTime.UtcNow);

        _handler = new RegisterAgentCommandHandler(
            _companyRepositoryMock,
            _userRepositoryMock,
            _unitOfWorkMock,
            _dateTimeProviderMock
        );
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenCompanyIsNULL()
    {
        // Arrange
        _companyRepositoryMock
            .GetByIdAsync(Command.companyId, Arg.Any<CancellationToken>())
            .Returns((Company?)null);

        //Act
        var result = await _handler.Handle(Command, default);

        //Assert
        result.Error.Should().Be(CompanyErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenAnAgentIsRegistered()
    {
        // Arrange
        var company = CompanyData.Create();
        // Arrange

        _companyRepositoryMock
            .GetByIdAsync(Command.companyId, Arg.Any<CancellationToken>())
            .Returns(company);

        // Act
        var result = await _handler.Handle(Command, default);

        //assert
        result.IsSuccess.Should().BeTrue();
    }
}

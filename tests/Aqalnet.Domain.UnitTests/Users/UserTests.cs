using Aqalnet.Domain.Users;
using FluentAssertions;

namespace Aqalnet.Domain.UnitTests.Users;

public class UserTests
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        // Arrange
        //using the userdata class for Arrange


        //Act
        var user = User.Create(
            UserData.FirstName,
            UserData.LastName,
            UserData.Email,
            UserData.MobileNumber,
            UserData.CreatedAt,
            UserData.oid,
            UserData.ProfilePicture
        );

        //Assert
        user.FirstName.Should().Be(UserData.FirstName);
        user.LastName.Should().Be(UserData.LastName);
        user.Email.Should().Be(UserData.Email);
        user.MobileNumber.Should().Be(UserData.MobileNumber);
        user.Oid.Should().Be(UserData.oid);
        user.ProfilePicture.Should().Be(UserData.ProfilePicture);
        user.CreatedAt.Should().Be(UserData.CreatedAt);
    }
}

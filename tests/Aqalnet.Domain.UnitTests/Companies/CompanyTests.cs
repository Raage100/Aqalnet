using Aqalnet.Domain.Companies;
using Aqalnet.Domain.UnitTests.Infrastructure;
using FluentAssertions;
using Newtonsoft.Json.Bson;

namespace Aqalnet.Domain.UnitTests.Companies;

public class CompanyTests : BaseTest
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        // Arrange
        //using CompanyData class for Arrange

        // Act
        var company = Company.Create(
            CompanyData.CompanyName,
            CompanyData.Address,
            CompanyData.Logo,
            CompanyData.FirstName,
            CompanyData.LastName,
            CompanyData.Email,
            CompanyData.MobilePhone,
            CompanyData.ProfilePicture
        );

        // Assert
        company.CompanyName.Should().Be(CompanyData.CompanyName);
        company.Address.Should().Be(CompanyData.Address);
        company.Logo.Should().Be(CompanyData.Logo);
    }

    [Fact]
    public void Create_Should_RaiseCompanyCreatedDomainEvent()
    {
        //act
        var company = Company.Create(
            CompanyData.CompanyName,
            CompanyData.Address,
            CompanyData.Logo,
            CompanyData.FirstName,
            CompanyData.LastName,
            CompanyData.Email,
            CompanyData.MobilePhone,
            CompanyData.ProfilePicture
        );

        //assert
        var domainEvent = AssertDomainEventWasPublished<CompanyCreatedDomainEvent>(company);

        domainEvent.companyId.Should().Be(company.Id);
        domainEvent.firstName.Should().Be(CompanyData.FirstName);
        domainEvent.lastName.Should().Be(CompanyData.LastName);
        domainEvent.email.Should().Be(CompanyData.Email);
        domainEvent.mobilePhone.Should().Be(CompanyData.MobilePhone);
        domainEvent.profilePicture.Should().Be(CompanyData.ProfilePicture);
    }
}

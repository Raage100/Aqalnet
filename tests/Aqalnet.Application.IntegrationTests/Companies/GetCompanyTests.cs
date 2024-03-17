using Aqalnet.Application.Companies.GetCompany;
using Aqalnet.Application.IntegrationTests.Infrastructure;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Companies;
using FluentAssertions;

namespace Aqalnet.Application.IntegrationTests.Companies;

public class GetCompanyTests : BaseIntegrationTests
{
    private readonly Guid CompanyId = Guid.Parse("30e3c9d3-6e9d-4a2f-af1f-8d8de6a61f8d");

    public GetCompanyTests(IntegrationTestWebAppFactory factory)
        : base(factory) { }

    [Fact]
    public async Task CompanyExist_AfterSeeding()
    {
        var id = Guid.Parse("30e3c9d3-6e9d-4a2f-af1f-8d8de6a61f8d");
        var expectedCompanyName = "Raage";
        var query = new GetCompanyQuery(id);
        var result = await Sender.Send(query);

        result.Should().NotBeNull();
        result.Value.CompanyName.Should().Be(expectedCompanyName);
    }

    [Fact]
    public async Task GetCompany__ShouldReturnNotFound_WhenCompanyDoesNotExist()
    {
        //arrange
        var id = Guid.NewGuid();
        var query = new GetCompanyQuery(id);
        //act
        var result = await Sender.Send(query);

        //assert
        result.Should().NotBeNull();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CompanyErrors.NotFound);
    }
}

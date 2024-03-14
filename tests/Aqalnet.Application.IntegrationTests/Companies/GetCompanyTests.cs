using Aqalnet.Application.Companies.GetCompany;
using Aqalnet.Application.IntegrationTests.Infrastructure;
using FluentAssertions;

namespace Aqalnet.Application.IntegrationTests.Companies;

public class GetCompanyTests : BaseIntegrationTests
{
    public GetCompanyTests(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }


    [Fact]
    public async Task GetCompany_ShouldReturnFailure_WhenCompanyIsNULL()
    {
        var id = Guid.NewGuid();
        var query = new GetCompanyQuery(id);

        // Act
        var result = await Sender.Send(query);

        // Assert
        result.IsFailure.Should().BeTrue();

    }

}

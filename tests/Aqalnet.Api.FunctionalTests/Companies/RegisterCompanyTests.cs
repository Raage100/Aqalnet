using System.Net;
using System.Net.Http.Json;
using Aqalnet.Api.Controllers.Companies;
using Aqalnet.Api.FunctionalTests.infrastructure;
using Aqalnet.Application.Companies.RegisterCompany;
using FluentAssertions;

namespace Aqalnet.Api.FunctionalTests.Companies;

public class RegisterCompanyTests : BaseFunctionalTest
{
    public RegisterCompanyTests(FunctionalTestWebAppFactory factory)
        : base(factory) { }

    [Fact]
    public async Task RegisterCompany_ShouldReturnOK_WhenRequestIsValid()
    {
        //arrange

        var request = new RegisterCompanyRequest(
            "testName",
            "street",
            "city",
            "firstname",
            "lastname",
            "email",
            "04947",
            "urllogo",
            "pictureurl"
        );

        //act

        HttpResponseMessage response = await HttpClient.PostAsJsonAsync(
            "api/v1/companies/RegisterCompany",
            request
        );

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}

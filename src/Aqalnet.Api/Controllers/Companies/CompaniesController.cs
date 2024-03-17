using Aqalnet.Application.Companies.GetCompany;
using Aqalnet.Application.Companies.RegisterCompany;
using Aqalnet.Domain.Companies;
using Aqalnet.Domain.Users;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aqalnet.Api.Controllers.Companies;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ISender _sender;

    public CompaniesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetCompanyQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return NotFound(result.Error);
        }
        return Ok(result.Value);
    }

    [HttpPost("RegisterCompany")]
    public async Task<IActionResult> CreateCompany(
        RegisterCompanyRequest request,
        CancellationToken cancellationToken
    )
    {
        var command = new RegisterCompanyCommand(
            request.CompanyName,
            new Address(request.Street, request.City),
            request.FirstName,
            request.LastName,
            request.Email,
            request.MobileNumber,
            new Logo(request.logourl),
            new ProfilePicture(request.profilePictureUrl)
        );
        var result = await _sender.Send(command, cancellationToken);

        return result.IsFailure ? BadRequest(result.Error) : Ok(result.Value);
    }
}

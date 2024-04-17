using Aqalnet.Application.Cities.GetCitiesById;
using Aqalnet.Application.Cities.RegisterCity;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aqalnet.Api.Controllers.Cities;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/cities")]
public class CitiesController : ControllerBase
{
    private readonly ISender _sender;

    public CitiesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("RegisterCity")]
    public async Task<IActionResult> RegisterCity(RegisterCityRequest request)
    {
        var registerCityCommand = new RegisterCityCommand(request.CountryId, request.Name);
        var result = await _sender.Send(registerCityCommand);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCities(Guid id)
    {
        var getCitiesQuery = new GetCitiesByIdQuery(id);
        var result = await _sender.Send(getCitiesQuery);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}

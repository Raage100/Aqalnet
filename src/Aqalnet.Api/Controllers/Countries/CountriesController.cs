using Aqalnet.Application.Countries.GetCountries;
using Aqalnet.Application.Countries.RegisterCountry;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqalnet.Api.Controllers.Countries
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ISender _sender;

        public CountriesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("RegisterCountry")]
        public async Task<IActionResult> RegisterCountry(RegisterCountryRequest request)
        {
            var RegisterCountryCommand = new RegisterCountryCommand(request.Name);
            var result = await _sender.Send(RegisterCountryCommand);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("GetListOfCountries")]
        public async Task<IActionResult> GetCountries()
        {
            var getCountriesQuery = new GetCountriesQuery();
            var result = await _sender.Send(getCountriesQuery);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}

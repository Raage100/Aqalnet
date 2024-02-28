using Aqalnet.Application.Companies.GetCompany;
using Aqalnet.Application.Companies.RegisterCompany;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aqalnet.Api.Controllers.Companies;

  [Route("api/[controller]")]
  [ApiController]
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
          RegisterCompanyCommand command,
          CancellationToken cancellationToken
      )
      {
          var result = await _sender.Send(command, cancellationToken);

          return CreatedAtAction(nameof(GetCompany), new { id = result.Value }, result.Value);
      }
  }
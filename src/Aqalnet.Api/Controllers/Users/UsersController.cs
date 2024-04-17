using Aqalnet.Application.Users.GetUserById;
using Aqalnet.Application.Users.RegisterUser;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqalnet.Api.Controllers.Users;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/users")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
    {
        var RegisterUserCommand = new RegisterUserCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.MobileNumber,
            request.ProfilePicture,
            request.Oid
        );
        var result = await _sender.Send(RegisterUserCommand);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var getUseGetUserByIdQueryQuery = new GetUserByIdQuery(id);
        var result = await _sender.Send(getUseGetUserByIdQueryQuery);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}

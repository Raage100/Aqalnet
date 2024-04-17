using Aqalnet.Application.Propertys.GetAllProperties;
using Aqalnet.Application.Propertys.ListApartment;
using Aqalnet.Application.Propertys.ListHouse;
using Aqalnet.Application.Propertys.ListLand;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aqalnet.Api.Controllers.Propertys;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/properties")]
public class PropertyController : ControllerBase
{
    private readonly ISender _sender;

    public PropertyController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("ListApartment")]
    public async Task<IActionResult> ListApartment(ListApartmentRequest apartmentRequest)
    {
        var listApartmentCommand = new ListApartmentCommand(
            apartmentRequest.UserId,
            apartmentRequest.CityId,
            apartmentRequest.Price,
            apartmentRequest.About,
            apartmentRequest.Currency,
            apartmentRequest.Street,
            apartmentRequest.StreetNumber,
            apartmentRequest.HasParking,
            apartmentRequest.HasBalcony,
            apartmentRequest.Floor,
            apartmentRequest.HasElevator,
            apartmentRequest.YearBuilt,
            apartmentRequest.Area,
            apartmentRequest.NumberOfRooms,
            apartmentRequest.NumberOfToilets
        );

        var result = await _sender.Send(listApartmentCommand);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("ListHouse")]
    public async Task<IActionResult> ListHouse(ListHouseRequest houseRequest)
    {
        var listHouseCommand = new ListHouseCommand(
            houseRequest.UserId,
            houseRequest.CityId,
            houseRequest.Price,
            houseRequest.About,
            houseRequest.Currency,
            houseRequest.Street,
            houseRequest.StreetNumber,
            houseRequest.HasParking,
            houseRequest.HasGarage,
            houseRequest.NumberOfRooms,
            houseRequest.NumberOfFloors,
            houseRequest.NumberOfToilets,
            houseRequest.YéarBuilt,
            houseRequest.Area
        );

        var result = await _sender.Send(listHouseCommand);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("ListLand")]
    public async Task<IActionResult> ListLand(ListLandRequest landRequest)
    {
        var listLandCommand = new ListLandCommand(
            landRequest.UserId,
            landRequest.CityId,
            landRequest.Price,
            landRequest.About,
            landRequest.Currency,
            landRequest.Street,
            landRequest.Area,
            landRequest.Latitude,
            landRequest.Longitude
        );

        var result = await _sender.Send(listLandCommand);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("GetAllProperties")]
    public async Task<IActionResult> GetAllProperties()
    {
        var getAllPropertiesQuery = new GetAllPropertiesQuery(Guid.NewGuid());

        var result = await _sender.Send(getAllPropertiesQuery);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}

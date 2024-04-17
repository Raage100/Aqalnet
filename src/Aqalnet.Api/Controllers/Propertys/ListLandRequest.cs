namespace Aqalnet.Api.Controllers.Propertys;

public record ListLandRequest(
    Guid UserId,
    Guid CityId,
    decimal Price,
    string About,
    string Currency,
    string Street,
    decimal Area,
    decimal Longitude,
    decimal Latitude
);

namespace Aqalnet.Api.Controllers.Propertys;

public record ListHouseRequest(
    Guid UserId,
    Guid CityId,
    decimal Price,
    string About,
    string Currency,
    string Street,
    int StreetNumber,
    bool HasGarage,
    bool HasParking,
    int NumberOfRooms,
    int NumberOfFloors,
    int NumberOfToilets,
    DateOnly YéarBuilt,
    decimal Area
);

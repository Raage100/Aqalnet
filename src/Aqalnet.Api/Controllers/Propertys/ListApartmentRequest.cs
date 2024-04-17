namespace Aqalnet.Api.Controllers.Propertys;

public record ListApartmentRequest(
    Guid UserId,
    Guid CityId,
    decimal Price,
    string About,
    string Currency,
    string Street,
    int StreetNumber,
    bool HasParking,
    bool HasBalcony,
    int Floor,
    bool HasElevator,
    DateOnly YearBuilt,
    decimal Area,
    int NumberOfRooms,
    int NumberOfToilets
);

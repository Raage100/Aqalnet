using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Propertys.ListApartment;

public sealed record ListApartmentCommand(
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
) : ICommand<ListApartmentResponse>;

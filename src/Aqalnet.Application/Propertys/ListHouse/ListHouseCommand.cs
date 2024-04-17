using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Propertys.ListHouse;

public sealed record ListHouseCommand(
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
) : ICommand<ListHouseResponse>;

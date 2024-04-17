using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Propertys.ListLand;

public sealed record ListLandCommand(
    Guid UserId,
    Guid CityId,
    decimal Price,
    string About,
    string Currency,
    string Street,
    decimal Area,
    decimal Latitude,
    decimal Longitude
) : ICommand<ListLandResponse>;

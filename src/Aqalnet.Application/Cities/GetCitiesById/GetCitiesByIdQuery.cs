using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Cities.GetCitiesById;

public sealed record GetCitiesByIdQuery(Guid CountryId) : IQuery<IReadOnlyList<CityResponse>>;

using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Countries.GetCountries;

public record GetCountriesQuery() : IQuery<IReadOnlyList<CountryResponse>>;

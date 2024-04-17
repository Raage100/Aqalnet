using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Cities.RegisterCity;

public sealed record RegisterCityCommand(Guid CountryId, string Name) : ICommand<Guid>;

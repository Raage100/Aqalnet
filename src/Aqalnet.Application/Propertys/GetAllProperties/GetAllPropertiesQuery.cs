using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Propertys.GetAllProperties;

public record GetAllPropertiesQuery(Guid UserId) : IQuery<IReadOnlyList<PropertyResponse>>;

using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Propertys.GetAllApartments;

public record GetAllApartmentsQuery() : IQuery<IReadOnlyList<GetAllApartmentsResponse>>;

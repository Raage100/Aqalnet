using Aqalnet.Application.Abstractions.Caching;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Application.Propertys.GetAllApartments;

internal sealed class GetAllApartmentQueryHandler
    : IQueryHandler<GetAllApartmentsQuery, IReadOnlyList<GetAllApartmentsResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly ICacheService _cacheService;

    public GetAllApartmentQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        ICacheService cacheService
    )
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _cacheService = cacheService;
    }

    public Task<Result<IReadOnlyList<GetAllApartmentsResponse>>> Handle(
        GetAllApartmentsQuery request,
        CancellationToken cancellationToken
    )
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        var lista = new GetAllApartmentsResponse();
        return null;
    }
}

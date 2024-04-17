using System.Data;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Cities;
using Dapper;

namespace Aqalnet.Application.Cities.GetCitiesById;

internal sealed class GetCitiesByIdQueryHandler
    : IQueryHandler<GetCitiesByIdQuery, IReadOnlyList<CityResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetCitiesByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<CityResponse>>> Handle(
        GetCitiesByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        using IDbConnection connection = _sqlConnectionFactory.CreateConnection();
        const string sql =
            @"
            SELECT 
            c.id As Id,
            name AS Name
            FROM cities c
            WHERE c.country_id = @countryId;
            ";

        IEnumerable<CityResponse> cities = await connection.QueryAsync<CityResponse>(
            sql,
            new { request.CountryId }
        );

        if (!cities.Any())
        {
            return Result.Failure<IReadOnlyList<CityResponse>>(CityErrors.NotFound);
        }
        return cities.ToList();
    }
}

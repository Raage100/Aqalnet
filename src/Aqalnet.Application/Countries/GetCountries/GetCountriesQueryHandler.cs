using System.Data;
using System.Data.Common;
using Aqalnet.Application.Abstractions.Caching;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Countries;
using Dapper;

namespace Aqalnet.Application.Countries.GetCountries;

internal sealed class GetCountriesQueryHandler
    : IQueryHandler<GetCountriesQuery, IReadOnlyList<CountryResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly ICacheService _cacheService;
    private const string CacheKeyPrefix = "Countries-";

    public GetCountriesQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        ICacheService cacheService
    )
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _cacheService = cacheService;
    }

    public async Task<Result<IReadOnlyList<CountryResponse>>> Handle(
        GetCountriesQuery request,
        CancellationToken cancellationToken
    )
    {
        string cacheKey = $"{CacheKeyPrefix}All";

        var cachedCountries = await _cacheService.GetAsync<IReadOnlyCollection<CountryResponse>>(
            cacheKey,
            cancellationToken
        );
        if (cachedCountries != null)
        {
            return cachedCountries.ToList();
        }
        using IDbConnection connection = _sqlConnectionFactory.CreateConnection();
        const string sql =
            @"
            SELECT 
                c.id As Id,
                name AS Name
            FROM countries c
            ";

        var countries = await connection.QueryAsync<CountryResponse>(sql);

        if (!countries.Any())
        {
            return Result.Failure<IReadOnlyList<CountryResponse>>(CountryErrors.NotFound);
        }

        await _cacheService.SetAsync(
            cacheKey,
            countries,
            TimeSpan.FromMinutes(3),
            cancellationToken
        );
        return countries.ToList();
    }
}

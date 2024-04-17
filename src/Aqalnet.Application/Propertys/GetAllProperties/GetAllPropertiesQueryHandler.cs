using System.Data;
using Aqalnet.Application.Abstractions.Caching;
using Aqalnet.Application.Abstractions.Data;
using Aqalnet.Application.Abstractions.Messaging;
using Aqalnet.Domain.Abstractions;
using Dapper;
using Newtonsoft.Json;

namespace Aqalnet.Application.Propertys.GetAllProperties;

internal sealed class GetAllPropertiesQueryHandler
    : IQueryHandler<GetAllPropertiesQuery, IReadOnlyList<PropertyResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly ICacheService _cacheService;
    private const string CacheKeyPrefix = "Properties-";

    public GetAllPropertiesQueryHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        ICacheService cacheService
    )
    {
        _sqlConnectionFactory = sqlConnectionFactory;
        _cacheService = cacheService;
    }

    public async Task<Result<IReadOnlyList<PropertyResponse>>> Handle(
        GetAllPropertiesQuery request,
        CancellationToken cancellationToken
    )
    {
        string cacheKey = $"{CacheKeyPrefix}All";
        var cachedProperties = await _cacheService.GetAsync<IReadOnlyList<PropertyResponse>>(
            cacheKey,
            cancellationToken
        );
        if (cachedProperties != null)
        {
            return cachedProperties.ToList();
        }
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql =
            @"
                 SELECT
                     p.id,
                     p.property_type AS PropertyType,
                     p.user_id AS UserId,
                     p.street_number AS StreetNumber,
                     p.street AS Street,
                     p.about AS About,
                     p.date_published AS DatePublished,
                     p.is_published AS IsPublished,
                     p.price AS Price,
                     p.currency AS Currency,
                     p.price_per_square_meter as PricePerSquareMeter ,
                     p.area AS Area,
                     c.name AS City,
                     a.floor as Floor,
                     a.has_balcony as HasBalcony,
                     a.has_elevator HasElevator,
                     h.has_garage as Hasgarage,
                     l.latitude as Latitude,
                     l.longitude as Longitude,
                     coalesce(a.has_parking, h.has_parking) as HasParking,
                     coalesce(a.number_of_rooms, h.number_of_rooms) as NumberOfRooms,
                     coalesce(a.number_of_toilets, h.number_of_toilets) as NumberOfToilets,
                     coalesce(a.year_built, h.year_built) as YearBuilt,
                     coalesce(a.id, h.id, l.id) as PropertyVariantId,
                     u.id , u.email AS Email, u.first_name AS FirstName, u.last_name AS LastName, u.mobile_number AS MobileNumber, u.profile_picture_url AS ProfilePicture,
                     i.id , i.property_id AS PropertyId, i.alt, i.description, i.title, i.url
                 FROM properties p
                          INNER JOIN users u on p.user_id = u.id
                          INNER JOIN cities c on p.city_id = c.id
                          LEFT JOIN images i ON p.id = i.property_id
                          LEFT JOIN apartments a ON p.id = a.property_id
                          LEFT JOIN houses h ON p.id = h.property_id
                          LEFT JOIN lands l on p.id = l.property_id
                 ORDER BY p.date_published DESC;

         ";

        var propertyDictionary = new Dictionary<Guid, PropertyResponse>();

        var result = await connection.QueryAsync<
            PropertyResponse,
            UserResponse,
            ImageResponse,
            PropertyResponse
        >(
            sql,
            (property, user, image) =>
            {
                if (!propertyDictionary.TryGetValue(property.Id, out var propertyEntry))
                {
                    propertyEntry = property;
                    propertyEntry.User = user;
                    propertyDictionary.Add(propertyEntry.Id, propertyEntry);
                }

                if (image != null && image.Id != Guid.Empty)
                {
                    propertyEntry.Images.Add(image);
                }

                return propertyEntry;
            },
            splitOn: "id"
        );

        await _cacheService.SetAsync(
            cacheKey,
            propertyDictionary.Values.ToList(),
            TimeSpan.FromMinutes(5),
            cancellationToken
        );
        return propertyDictionary.Values.ToList();
    }
}

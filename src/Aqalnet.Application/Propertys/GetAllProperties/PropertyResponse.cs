namespace Aqalnet.Application.Propertys.GetAllProperties;

public class PropertyResponse
{
    public Guid Id { get; init; }
    public int PropertyType { get; init; }
    public Guid UserId { get; init; }
    public string City { get; init; }
    public int StreetNumber { get; init; }
    public string About { get; init; }
    public string Street { get; init; }
    public DateTime DatePublished { get; init; }
    public bool IsPublished { get; init; }
    public decimal Price { get; init; }
    public string Currency { get; init; }
    public decimal? Area { get; init; }
    public int? Floor { get; init; }
    public bool? HasBalcony { get; init; }
    public bool? HasElevator { get; init; }
    public bool HasParking { get; init; }
    public int NumberOfRooms { get; init; }
    public int NumberOfToilets { get; init; }
    public decimal PricePerSquareMeter { get; init; }
    public DateOnly YearBuilt { get; init; }
    public Guid PropertyVariantId { get; init; }
    public bool? HasGarage { get; init; }
    public int? NumberOfFloors { get; init; }
    public decimal Latitude { get; init; }
    public decimal Longitude { get; init; }

    public UserResponse User { get; set; }

    public List<ImageResponse> Images { get; init; } = new();
}

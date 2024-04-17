using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Domain.Propertys;

public class Property : AggregateRoot
{
    private Property(
        Guid id,
        Guid userId,
        Guid cityId,
        Money price,
        About about,
        Address address,
        PropertyType propertyType,
        IsPublished isPublished,
        Area area,
        PricePerSquareMeter pricePerSquareMeter,
        House? house = null,
        Apartment? apartment = null,
        Land? land = null
    )
        : base(id)
    {
        UserId = userId;
        CityId = cityId;
        Price = price;
        About = about;
        Address = address;
        PropertyType = propertyType;
        IsPublished = isPublished;
        Area = area;
        PricePerSquareMeter = pricePerSquareMeter;
        House = house;
        Apartment = apartment;
        Land = land;
    }

    public Money Price { get; private set; }
    public About About { get; private set; }
    public Address Address { get; private set; }
    public IsPublished IsPublished { get; private set; }
    public PropertyType PropertyType { get; private set; }

    public DatePublished DatePublished { get; private set; }

    public Area Area { get; private set; }

    public PricePerSquareMeter PricePerSquareMeter { get; private set; }

    public Guid UserId; // reference to the user who created the property

    public Guid CityId; // reference to the city

    public House? House { get; private set; }
    public Apartment? Apartment { get; private set; }
    public Land? Land { get; private set; }

    private List<Image> _images = new List<Image>();

    public IReadOnlyList<Image> GetImages()
    {
        return _images.AsReadOnly();
    }

    public void AddImage(Guid propertyId, Url url, Alt alt, Title title, Description description)
    {
        _images.Add(Image.Create(Guid.NewGuid(), propertyId, url, alt, title, description));
    }

    public static Property CreateHouse(
        Guid userId,
        Guid cityId,
        Money price,
        About about,
        Address address,
        HasGarage hasGarage,
        HasParking hasParking,
        NumberOfRooms numberOfRooms,
        NumberOfFloors numberOfFloors,
        NumberOfToilets numberOfToilets,
        YearBuilt yearBuilt,
        Area area,
        PricingService pricingService
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            cityId,
            price,
            about,
            address,
            PropertyType.House,
            new IsPublished(true),
            area,
            new PricePerSquareMeter(pricingService.CalculatePrice(price, area))
        );

        var house = property.House = House.Create(
            property.Id,
            hasGarage,
            hasParking,
            numberOfRooms,
            numberOfFloors,
            numberOfToilets,
            yearBuilt
        );
        property.DatePublished = new DatePublished(DateOnly.FromDateTime(DateTime.UtcNow));

        return property;
    }

    public static Property CreateApartment(
        Guid userId,
        Guid cityId,
        Money price,
        About about,
        Address address,
        HasParking hasParking,
        HasBalcony hasBalcony,
        Floor floor,
        HasElevator hasElevator,
        YearBuilt yearBuilt,
        NumberOfRooms numberOfRooms,
        NumberOfToilets numberOfToilets,
        Area area,
        PricingService pricingService
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            cityId,
            price,
            about,
            address,
            PropertyType.Apartment,
            new IsPublished(true),
            area,
            new PricePerSquareMeter(pricingService.CalculatePrice(price, area))
        );

        property.Apartment = Apartment.Create(
            property.Id,
            hasParking,
            hasBalcony,
            floor,
            hasElevator,
            yearBuilt,
            numberOfRooms,
            numberOfToilets
        );
        property.DatePublished = new DatePublished(DateOnly.FromDateTime(DateTime.UtcNow));

        return property;
    }

    public static Property CreateLand(
        Guid userId,
        Guid cityId,
        Money price,
        About about,
        Address address,
        Area area,
        Longitude longitude,
        Latitude latitude,
        PricingService pricingService
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            cityId,
            price,
            about,
            address,
            PropertyType.Land,
            new IsPublished(true),
            area,
            new PricePerSquareMeter(pricingService.CalculatePrice(price, area))
        );
        property.Land = Land.Create(Guid.NewGuid(), property.Id, longitude, latitude);
        property.DatePublished = new DatePublished(DateOnly.FromDateTime(DateTime.UtcNow));

        return property;
    }

    public Property() { }
}

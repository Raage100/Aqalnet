using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public class Property : AggregateRoot
{
    private Property(
        Guid id,
        Guid userId,
        Guid? companyId,
        decimal price,
        Address address,
        PropertyType propertyType,
        House? house = null,
        Apartment? apartment = null,
        Land? land = null
    )
        : base(id)
    {
        UserId = userId;
        CompanyId = companyId;

        Price = price;
        Address = address;
        PropertyType = propertyType;
        House = house;
        Apartment = apartment;
        Land = land;
    }

    public decimal Price { get; private set; }
    public Address Address { get; private set; }
    public bool IsPublished { get; private set; }
    public PropertyType PropertyType { get; private set; }

    

    public DateOnly DatePublished { get; private set; }

    public Guid UserId; // reference to the user who created the property

    public Guid? CompanyId; // reference to the company that owns the property
    public House? House { get; private set; }
    public Apartment? Apartment { get; private set; }
    public Land? Land { get; private set; }

    private List<Image> _images = new List<Image>();

    public IReadOnlyList<Image> GetImages()
    {
        return _images.AsReadOnly();
    }

    public void AddImage(Guid propertyId, string url, string alt, string title, string description)
    {
        _images.Add(Image.Create(Guid.NewGuid(), propertyId, url, alt, title, description));
    }

    public static Property CreateHouse(
        Guid userId,
        Guid companyId,
        decimal price,
        Address address,
        bool hasGarage,
        bool hasParking,
        int numberOfRooms,
        int numberofFloors,
        DateOnly yearBuilt,
        decimal plotArea,
        decimal buildingArea,
        decimal pricePerSquareMeter
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            companyId,
            price,
            address,
            PropertyType.House
        );
        property.House = House.Create(
            property.Id,
            hasGarage,
            hasParking,
            numberOfRooms,
            numberofFloors,
            yearBuilt,
            plotArea,
            buildingArea,
            pricePerSquareMeter
        );
        property.DatePublished = DateOnly.FromDateTime(DateTime.UtcNow);
        return property;
    }

    public static Property CreateApartment(
        
        Guid userId,
        Guid companyId,
        decimal price,
        Address address,
        bool hasParking,
        bool hasBalcony,
        int floor,
        bool hasElevator,
        DateOnly yearBuilt,
        decimal pricePerSquareMeter,
        decimal livingArea,
        int numberOfRooms,
        int numberOfToilets
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            companyId,
            price,
            address,
            PropertyType.Apartment
        );
        property.Apartment = Apartment.Create(Guid.NewGuid(), hasParking,hasBalcony,floor,hasElevator,yearBuilt,pricePerSquareMeter,livingArea,numberOfRooms,numberOfToilets);
        property.DatePublished = DateOnly.FromDateTime(DateTime.UtcNow);
        return property;
    }

    public static Property CreateLand(
        
        Guid userId,
        Guid companyId,
        decimal price,
        Address address,
        decimal area,
        decimal pricePerSquareMeter
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            companyId,
            price,
            address,
            PropertyType.Land
        );
        property.Land = Land.Create(Guid.NewGuid(), property.Id, area, pricePerSquareMeter);
        property.DatePublished = DateOnly.FromDateTime(DateTime.UtcNow);
        return property;
    }

    public Property() { }
}

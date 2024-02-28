using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public class Property : AggregateRoot
{
    private Property(
        Guid id,
        Guid userId,
        Guid? companyId,
        string name,
        string description,
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
        Name = name;
        Description = description;
        Price = price;
        Address = address;
        PropertyType = propertyType;
        House = house;
        Apartment = apartment;
        Land = land;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public Address Address { get; private set; }
    public bool IsPublished { get; private set; }
    public PropertyType PropertyType { get; private set; }

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
        Guid id,
        Guid userId,
        Guid companyId,
        string name,
        string description,
        decimal price,
        Address address,
        bool hasGarage
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            companyId,
            name,
            description,
            price,
            address,
            PropertyType.House
        );
        property.House = House.Create(property.Id, Guid.NewGuid(), hasGarage);
        return property;
    }

    public static Property CreateApartment(
        Guid id,
        Guid userId,
        Guid companyId,
        string name,
        string description,
        decimal price,
        Address address,
        bool hasParking
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            companyId,
            name,
            description,
            price,
            address,
            PropertyType.Apartment
        );
        property.Apartment = Apartment.Create(Guid.NewGuid(), property.Id, hasParking);
        return property;
    }

    public static Property CreateLand(
        Guid id,
        Guid userId,
        Guid companyId,
        string name,
        string description,
        decimal price,
        Address address,
        int area
    )
    {
        var property = new Property(
            Guid.NewGuid(),
            userId,
            companyId,
            name,
            description,
            price,
            address,
            PropertyType.Land
        );
        property.Land = Land.Create(Guid.NewGuid(), property.Id, area);
        return property;
    }

    public Property() { }
}

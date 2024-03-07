using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public sealed class Apartment : Entity
{
    private Apartment(
        Guid id,
        Guid propertyId,
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
        : base(id)
    {
        PropertyId = propertyId;
        HasParking = hasParking;
        HasBalcony = hasBalcony;
        Floor = floor;
        HasElevator = hasElevator;
        YearBuilt = yearBuilt;
        PricePerSquareMeter = pricePerSquareMeter;
        LivingArea = livingArea;
        NumberOfRooms = numberOfRooms;
        NumberOfToilets = numberOfToilets;
    }

    public Guid PropertyId { get; private set; }
    public bool HasParking { get; private set; }

    public bool HasBalcony { get; private set; }
    public int Floor { get; private set; }
    public bool HasElevator { get; private set; }
    public DateOnly YearBuilt { get; private set; }

    public decimal PricePerSquareMeter { get; set; }

    public decimal LivingArea { get; set; }
    public int NumberOfRooms { get; private set; }
    public int NumberOfToilets { get; private set; }

    public static Apartment Create(
        Guid propertyId,
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
        return new Apartment(
            Guid.NewGuid(),
            propertyId,
            hasParking,
            hasBalcony,
            floor,
            hasElevator,
            yearBuilt,
            pricePerSquareMeter,
            livingArea,
            numberOfRooms,
            numberOfToilets
        );
    }

    public Apartment() { }
}

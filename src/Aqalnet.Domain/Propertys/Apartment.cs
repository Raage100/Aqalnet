using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Domain.Propertys;

public sealed class Apartment : Entity
{
    private Apartment(
        Guid id,
        Guid propertyId,
        HasParking hasParking,
        HasBalcony hasBalcony,
        Floor floor,
        HasElevator hasElevator,
        YearBuilt yearBuilt,
        NumberOfRooms numberOfRooms,
        NumberOfToilets numberOfToilets
    )
        : base(id)
    {
        HasParking = hasParking;
        HasBalcony = hasBalcony;
        Floor = floor;
        HasElevator = hasElevator;
        YearBuilt = yearBuilt;
        NumberOfRooms = numberOfRooms;
        NumberOfToilets = numberOfToilets;
    }

    public HasParking HasParking { get; private set; }

    public HasBalcony HasBalcony { get; private set; }
    public Floor Floor { get; private set; }
    public HasElevator HasElevator { get; private set; }
    public YearBuilt YearBuilt { get; private set; }
    public NumberOfRooms NumberOfRooms { get; private set; }
    public NumberOfToilets NumberOfToilets { get; private set; }
    public Guid PropertyId { get; private set; }
    public Property Property { get; private set; }

    public static Apartment Create(
        Guid propertyId,
        HasParking hasParking,
        HasBalcony hasBalcony,
        Floor floor,
        HasElevator hasElevator,
        YearBuilt yearBuilt,
        NumberOfRooms numberOfRooms,
        NumberOfToilets numberOfToilets
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
            numberOfRooms,
            numberOfToilets
        );
    }

    public Apartment() { }
}

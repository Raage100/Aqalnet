using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Domain.Propertys;

public sealed class House : Entity
{
    private House(
        Guid id,
        Guid propertyId,
        HasGarage hasGarage,
        HasParking hasParking,
        NumberOfRooms numberOfRooms,
        NumberOfFloors numberOfFloors,
        NumberOfToilets numberOfToilets,
        YearBuilt yearBuilt
    )
        : base(id)
    {
        PropertyId = propertyId;
        HasGarage = hasGarage;
        HasParking = hasParking;
        NumberOfRooms = numberOfRooms;
        NumberOfFloors = numberOfFloors;
        NumberOfToilets = numberOfToilets;
        YearBuilt = yearBuilt;
    }

    public HasGarage HasGarage { get; private set; }
    public HasParking HasParking { get; private set; }
    public NumberOfRooms NumberOfRooms { get; private set; }
    public NumberOfFloors NumberOfFloors { get; private set; }

    public NumberOfToilets NumberOfToilets { get; private set; }
    public YearBuilt YearBuilt { get; private set; }

    public Guid PropertyId { get; private set; } // Foreign Key to Property
    public Property Property { get; private set; }

    public static House Create(
        Guid propertyId,
        HasGarage hasGarage,
        HasParking hasParking,
        NumberOfRooms numberOfRooms,
        NumberOfFloors numberOfFloors,
        NumberOfToilets numberOfToilets,
        YearBuilt yearBuilt
    )
    {
        return new House(
            Guid.NewGuid(),
            propertyId,
            hasGarage,
            hasParking,
            numberOfRooms,
            numberOfFloors,
            numberOfToilets,
            yearBuilt
        );
    }

    public House() { }
}

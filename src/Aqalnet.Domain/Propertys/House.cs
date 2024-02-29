using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public sealed class House : Entity
{
    private House(
        Guid id,
        Guid propertyId,
        bool hasGarage,
        bool hasParking,
        int numberOfRooms,
        int numberOfFloors,
        DateOnly yearBuilt,
        decimal plotArea,
        decimal buildingArea,
        decimal pricePerSquareMeter
    )
        : base(id)
    {
        PropertyId = propertyId;
        HasGarage = hasGarage;
        HasParking = hasParking;
        NumberOfRooms = numberOfRooms;
        NumberOfFloors = numberOfFloors;
        YearBuilt = yearBuilt;
        PlotArea = plotArea;
        BuildingArea = buildingArea;
        PricePerSquareMeter = pricePerSquareMeter;
    }

    public Guid PropertyId { get; private set; }
    public bool HasGarage { get; private set; }
    public bool HasParking { get; private set; }

    public int NumberOfRooms { get; private set; }
    public int NumberOfFloors { get; private set; }
    public DateOnly YearBuilt { get; private set; }
    public decimal PlotArea { get; private set; }
    public decimal BuildingArea { get; private set; }
    public decimal PricePerSquareMeter { get; set; }

    public static House Create(
        Guid propertyId,
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
        return new House(
            Guid.NewGuid(),
            propertyId,
            hasGarage,
            hasParking,
            numberOfRooms,
            numberofFloors,
            yearBuilt,
            plotArea,
            buildingArea,
            pricePerSquareMeter
        );
    }

    public House() { }
}

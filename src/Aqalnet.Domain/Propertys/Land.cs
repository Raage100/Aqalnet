using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Domain.Propertys;

public sealed class Land : Entity
{
    private Land(Guid id, Guid propertyId, Longitude longitude, Latitude latitude)
        : base(id)
    {
        PropertyId = propertyId;
        Longitude = longitude;
        Latitude = latitude;
    }

    public Guid PropertyId { get; private set; } // Foreign Key to Property
    public Property Property { get; private set; }
    public Longitude Longitude { get; private set; }
    public Latitude Latitude { get; private set; }

    public static Land Create(Guid id, Guid propertyId, Longitude longitude, Latitude latitude)
    {
        return new Land(Guid.NewGuid(), propertyId, longitude, latitude);
    }

    public Land() { }
}

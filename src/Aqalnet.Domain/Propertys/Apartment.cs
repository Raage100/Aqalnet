using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public sealed class Apartment : Entity
{
    private Apartment(Guid id, Guid propertyId, bool hasParking)
        : base(id)
    {
        HasParking = hasParking;
        PropertyId = propertyId;
    }

    public bool HasParking { get; private set; }

    public Guid PropertyId { get; private set; }

    public static Apartment Create(Guid id, Guid propertyId, bool hasParking)
    {
        return new Apartment(id, propertyId, hasParking);
    }

    public Apartment() { }
}

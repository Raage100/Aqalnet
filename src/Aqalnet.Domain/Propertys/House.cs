using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public sealed class House : Entity
{
    private House(Guid id, Guid propertyId, bool hasGarage)
        : base(id)
    {
        HasGarage = hasGarage;
        PropertyId = propertyId;
    }

    public Guid PropertyId { get; private set; }
    public bool HasGarage { get; private set; }

    public static House Create(Guid id, Guid propertyId, bool hasGarage)
    {
        return new House(id, propertyId, hasGarage);
    }

    public House() { }
}

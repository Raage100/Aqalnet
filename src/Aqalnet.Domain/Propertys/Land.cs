using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public sealed class Land : Entity
{
    private Land(Guid id, Guid prorpertyId, int area)
        : base(id)
    {
        Area = area;
        PropertyId = prorpertyId;
    }

    public int Area { get; private set; }
    public Guid PropertyId { get; private set; }

    public static Land Create(Guid id, Guid propertyId, int area)
    {
        return new Land(id, propertyId, area);
    }

    public Land() { }
}

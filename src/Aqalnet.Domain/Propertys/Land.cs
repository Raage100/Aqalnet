using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public sealed class Land : Entity
{
    private Land(Guid id, Guid propertyId, decimal area, decimal pricePerSquareMeter ):base(id)
    {
        PropertyId = propertyId;
        Area = area;
        PricePerSquareMeter = pricePerSquareMeter;
       
    }

    public Guid PropertyId { get; private set; }
    public decimal Area { get; private set; }

    public decimal PricePerSquareMeter { get; set; }

 

    public static Land Create(Guid id, Guid propertyId, decimal area, decimal pricePerSquareMeter)
    {
        return new Land(Guid.NewGuid(), propertyId, area,pricePerSquareMeter);
    }

    public Land() { }

   
}

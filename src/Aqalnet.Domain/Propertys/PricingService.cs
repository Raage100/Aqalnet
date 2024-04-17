using Aqalnet.Domain.Propertys.ValueObjects;

namespace Aqalnet.Domain.Propertys;

public class PricingService
{
    public decimal CalculatePrice(Money price, Area area)
    {
        decimal pricePerSquareMeter = price.Amount / area.Value;

        return pricePerSquareMeter;
    }
}

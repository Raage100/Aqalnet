namespace Aqalnet.Domain.Propertys.ValueObjects;

public record PricePerSquareMeter
{
    public decimal Value { get; }

    public PricePerSquareMeter(decimal value)
    {
        Value = value;
    }
}

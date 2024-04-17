namespace Aqalnet.Domain.Propertys.ValueObjects;

public record Area
{
    public decimal Value { get; }

    public Area(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Area cannot be negative");
        }
        Value = value;
    }
}

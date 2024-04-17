namespace Aqalnet.Domain.Propertys.ValueObjects;

public record Longitude
{
    public decimal Value { get; }

    public Longitude(decimal value)
    {
        if (value < -180 || value > 180)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Longitude must be between -180 and 180"
            );
        }
        Value = value;
    }
}

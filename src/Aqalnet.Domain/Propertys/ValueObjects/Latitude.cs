namespace Aqalnet.Domain.Propertys.ValueObjects;

public record Latitude
{
    public decimal Value { get; }

    public Latitude(decimal value)
    {
        if (value < -90 || value > 90)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Latitude must be between -90 and 90 degrees."
            );
        }

        Value = value;
    }
}

namespace Aqalnet.Domain.Propertys.ValueObjects;

public record NumberOfFloors
{
    public int Value { get; }

    public NumberOfFloors(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Number of floors cannot be negative."
            );
        }
        Value = value;
    }
}

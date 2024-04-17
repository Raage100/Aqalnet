namespace Aqalnet.Domain.Propertys.ValueObjects;

public record NumberOfRooms
{
    public int Value { get; }

    public NumberOfRooms(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Number of rooms cannot be negative."
            );
        }
        Value = value;
    }
}

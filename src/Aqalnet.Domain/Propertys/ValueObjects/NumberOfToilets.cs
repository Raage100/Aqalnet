namespace Aqalnet.Domain.Propertys.ValueObjects;

public record NumberOfToilets
{
    public int Value { get; }

    public NumberOfToilets(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Number of toilets cannot be negative"
            );
        }

        Value = value;
    }
}

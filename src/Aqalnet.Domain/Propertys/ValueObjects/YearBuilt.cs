namespace Aqalnet.Domain.Propertys.ValueObjects;

public record YearBuilt
{
    public DateOnly Value { get; }

    public YearBuilt(DateOnly value)
    {
        if (value > DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Year built cannot be in the future."
            );
        }
        Value = value;
    }
}

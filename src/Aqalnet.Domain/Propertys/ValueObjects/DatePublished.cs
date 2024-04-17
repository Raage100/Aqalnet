namespace Aqalnet.Domain.Propertys.ValueObjects;

public record DatePublished
{
    public DateOnly Value { get; }

    public DatePublished(DateOnly value)
    {
        Value = value;
    }
}

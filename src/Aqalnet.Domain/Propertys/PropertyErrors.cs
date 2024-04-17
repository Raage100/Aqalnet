using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Propertys;

public static class PropertyErrors
{
    public static Error NotCreated => new("Property.Created", "Property was not created");
}

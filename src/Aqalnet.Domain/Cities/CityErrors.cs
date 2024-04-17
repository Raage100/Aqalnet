using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Cities;

public static class CityErrors
{
    public static Error NotCreated => new("City.NotCreated", "City could not be created.");
    public static Error NotFound => new("Cities.NotFound", "Cities not found.");

    public static Error CityAlreadyExists => new("City.AlreadyExists", "City already exists.");
}

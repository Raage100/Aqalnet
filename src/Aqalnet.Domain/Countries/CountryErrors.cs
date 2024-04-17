using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Countries;

public static class CountryErrors
{
    public static Error NotCreated => new("Country.NotCreated", "Country could not be created");

    public static Error NotFound => new("Country.NotFound", "Country not found");
}

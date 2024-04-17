using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Cities;

public class City : AggregateRoot
{
    private City(Guid id, Guid countryId, Name name)
        : base(id)
    {
        CountryId = countryId;
        Name = name;
    }

    public Name Name { get; private set; }
    public Guid CountryId; //foreign key to Country

    public static City Create(Guid id, Guid countryId, Name name)
    {
        return new City(id, countryId, name);
    }

    public City() { }
}

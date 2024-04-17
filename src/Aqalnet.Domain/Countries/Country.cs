using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Countries;

public class Country : AggregateRoot
{
    private Country(Guid id, Name name)
        : base(id)
    {
        Name = name;
    }

    public Name Name { get; set; }

    public static Country Create(Guid id, Name name)
    {
        return new Country(id, name);
    }

    public Country() { }
}

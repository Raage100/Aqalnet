using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Companies;

public sealed class Company : AggregateRoot
{
    public Company(Guid id, string companyName, Address address)
        : base(id)
    {
        CompanyName = companyName;
        Address = address;
    }

    public string CompanyName { get; private set; }
    public Address Address { get; private set; }

    public Logo Logo { get; private set; }

    public static Company Create(string companyName, Address address)
    {
        var company = new Company(Guid.NewGuid(), companyName, address);
        company.RaiseDomainEvent(new CompanyCreatedDomainEvent(company.Id));
        return company;
    }

    public Company() { }
}

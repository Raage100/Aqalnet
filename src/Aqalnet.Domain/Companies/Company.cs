using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Companies;

public sealed class Company : AggregateRoot
{

    private Company(Guid id, string companyName, Address address, Logo logo):base(id)
    {
        CompanyName = companyName;
        Address = address;
        Logo = logo;
        _agents = new();

    }

    private List<Agent> _agents;

    public IReadOnlyList<Agent> Agents=> _agents.AsReadOnly();
    public string CompanyName { get; private set; }
    public Address Address { get; private set; }

    public Logo Logo { get; private set; }

    
    public static Company Create(string companyName, Address address, Logo logo)
    {
        var company = new Company(Guid.NewGuid(), companyName, address,logo);
       // company.RaiseDomainEvent(new CompanyCreatedDomainEvent(company.Id));
        return company;
    }

    public void AddAgent(Agent agent){
        if(agent == null){
            throw new ArgumentNullException(nameof(agent), "agent cannot be null");
        }
        else{
            _agents.Add(agent);
        }
    }
    public static Agent CreateAgent( Guid companyId,string firstName, string lastName, string email, string mobileNumber, string title, Guid userId){


        var agent = Agent.Create(companyId,firstName,lastName,email,mobileNumber,title,userId);
   
        return agent;
    }

    public Company() { }
}

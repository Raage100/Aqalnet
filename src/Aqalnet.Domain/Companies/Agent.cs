using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Companies;

public sealed class Agent : Entity
{

    private Agent(Guid id, Guid companyId, string firstName, string lastName, string email, string mobileNumber, string title, Guid userId):base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        MobileNumber = mobileNumber;
        Title = title;
        CompanyId = companyId;
        UserId = userId;
    }



    public static Agent Create( Guid companyId,string firstName, string lastName, string email, string mobileNumber, string title, Guid userId){
        
            var agent = new Agent( Guid.NewGuid(),companyId,firstName,lastName,email, mobileNumber,title,userId );
            return agent;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public string MobileNumber { get; private set; }

    public string Title {get; private set;}
    public Guid CompanyId {get; private set;}

    public Guid UserId {get; private set;}


}

using Aqalnet.Domain.Abstractions;

namespace Aqalnet.Domain.Companies;

public sealed class Agent : Entity
{
    private Agent(
        Guid id,
        string firstName,
        string lastName,
        string title,
        string email,
        string mobilePhone,
        Guid companyId
    )
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Title = title;
        Email = email;
        MobileNumber = mobilePhone;
        CompanyId = companyId;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Title { get; private set; }
    public string Email { get; private set; }
    public string MobileNumber { get; private set; }

    public Guid CompanyId;

    public static Agent Create(
        Guid id,
        string firstName,
        string lastName,
        string title,
        string email,
        string mobilePhone,
        Guid companyId
    )
    {
        return new Agent(id, firstName, lastName, title, email, mobilePhone, companyId);
    }
}

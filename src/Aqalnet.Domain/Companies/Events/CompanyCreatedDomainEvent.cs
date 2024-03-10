using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Users;

namespace Aqalnet.Domain.Companies;

public record CompanyCreatedDomainEvent(
    Guid companyId,
    string firstName,
    string lastName,
    string email,
    string mobilePhone,
    ProfilePicture profilePicture
) : IDomainEvent;

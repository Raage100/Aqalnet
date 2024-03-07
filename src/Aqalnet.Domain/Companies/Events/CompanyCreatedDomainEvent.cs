using Aqalnet.Domain.Abstractions;
using Aqalnet.Domain.Users;

namespace Aqalnet.Domain.Companies;

public record CompanyCreatedDomainEvent(Guid companyId, Guid userId) : IDomainEvent;

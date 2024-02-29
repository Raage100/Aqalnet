using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Companies.GetCompany;

public record GetCompanyQuery(Guid CompanyId) : IQuery<CompanyResponse>;

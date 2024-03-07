using Aqalnet.Application.Abstractions.Caching;
using Aqalnet.Application.Abstractions.Messaging;

namespace Aqalnet.Application.Companies.GetCompany;

public record GetCompanyQuery(Guid CompanyId) : ICachedQuery<CompanyResponse>
{
    public string CacheKey =>  $"Company-{CompanyId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(1);
}

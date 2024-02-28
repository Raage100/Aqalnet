using Aqalnet.Domain.Companies;

namespace Aqalnet.Infrastructure.Repositories;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}

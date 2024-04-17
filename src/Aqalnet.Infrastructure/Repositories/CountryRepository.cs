using Aqalnet.Domain.Countries;

namespace Aqalnet.Infrastructure.Repositories;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}

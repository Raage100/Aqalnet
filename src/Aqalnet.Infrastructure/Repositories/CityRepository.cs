using Aqalnet.Domain.Cities;
using Microsoft.EntityFrameworkCore;

namespace Aqalnet.Infrastructure.Repositories;

public class CityRepository : Repository<City>, ICityRepository
{
    public CityRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }

    public async Task<City?> GetCityByName(
        string name,
        CancellationToken cancellationToken = default
    )
    {
        return await DbContext
            .Set<City>()
            .FirstOrDefaultAsync(x => x.Name.Value.ToLower() == name, cancellationToken);
    }
}

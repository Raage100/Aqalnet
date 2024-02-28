using Aqalnet.Domain.Propertys;

namespace Aqalnet.Infrastructure.Repositories;

public class PropertyRepository : Repository<Property>, IPropertyRepository
{
    public PropertyRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}

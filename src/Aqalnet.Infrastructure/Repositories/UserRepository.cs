using Aqalnet.Domain.Users;

namespace Aqalnet.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext) { }
}

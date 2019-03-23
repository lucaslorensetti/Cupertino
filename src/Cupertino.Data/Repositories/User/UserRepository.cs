using Cupertino.Core.Common;
using Cupertino.Data.Entities;
using Cupertino.Data.Repositories.Contracts;

namespace Cupertino.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using System;
using System.Threading.Tasks;
using Cupertino.Core.Common;
using Cupertino.Data.Contexts;
using Cupertino.Data.Entities;
using Cupertino.Data.Repositories.Contracts;

namespace Cupertino.Data.Repositories
{
    public class ErrorRepository : Repository<Error>, IErrorRepository
    {
        public ErrorRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public async Task LogAsync(Exception exception)
        {
            await this.InsertAsync(new Error
            {
                Exception = exception.ToString(),
                When = DateTime.UtcNow
            });
        }
    }
}

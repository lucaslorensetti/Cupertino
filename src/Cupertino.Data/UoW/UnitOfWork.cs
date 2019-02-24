using System;
using System.Threading.Tasks;
using Cupertino.Core;
using Cupertino.Core.Common;

namespace Cupertino.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            if (!await this.dbContext.HasChangesAsync())
            {
                return;
            }

            try
            {
                await this.dbContext.BeginTransactionAsync();

                await this.dbContext.SaveChangesAsync();

                await this.dbContext.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await this.dbContext.RollbackTransactionAsync();
                throw;
            }
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Cupertino.Core;
using Cupertino.Core.Common;
using Cupertino.Data.Entities;
using Cupertino.Data.Helpers;

namespace Cupertino.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity 
    {
        private readonly IDbContext dbContext;

        public Repository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return this.dbContext.GetQueryable<TEntity>();
        }
        
        public async Task InsertAsync(TEntity entity)
        {
            if (await AlreadyExists(entity))
            {
                throw new InvalidOperationException($"There is already an {nameof(TEntity)} with the same id.");
            }

            await this.dbContext.InsertAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (!await AlreadyExists(entity))
            {
                throw new InvalidOperationException($"There is no entity with this id on table {nameof(TEntity)}.");
            }

            await this.dbContext.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (!await AlreadyExists(entity))
            {
                throw new InvalidOperationException($"There is no entity with this id on table {nameof(TEntity)}.");
            }

            await this.dbContext.DeleteAsync(entity);
        }

        private async Task<bool> AlreadyExists(TEntity entity)
        {
            return await this.dbContext.GetQueryable<TEntity>().AnyAsync(x => x.Id == entity.Id);
        }
    }
}

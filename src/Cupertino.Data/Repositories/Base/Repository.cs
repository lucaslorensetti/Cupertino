using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cupertino.Core;
using Cupertino.Core.Common;
using Cupertino.Data.Entities;

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

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await this.dbContext.FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await this.dbContext.ToListAsync(filter);
        }

        public async Task<IEnumerable<TSelect>> GetManyAsync<TSelect>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TSelect>> selector)
        {
            return await this.dbContext.ToListAsync(filter, selector);
        }

        public async Task InsertAsync(TEntity entity)
        {
            if (await this.dbContext.AnyAsync<TEntity>(x => x.Id == entity.Id))
            {
                throw new InvalidOperationException($"There is already an {nameof(TEntity)} with the same id.");
            }

            await this.dbContext.InsertAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (!await this.dbContext.AnyAsync<TEntity>(x => x.Id == entity.Id))
            {
                throw new InvalidOperationException($"There is no entity with this id on table {nameof(TEntity)}.");
            }

            await this.dbContext.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (!await this.dbContext.AnyAsync<TEntity>(x => x.Id == entity.Id))
            {
                throw new InvalidOperationException($"There is no entity with this id on table {nameof(TEntity)}.");
            }

            await this.dbContext.DeleteAsync(entity);
        }
    }
}

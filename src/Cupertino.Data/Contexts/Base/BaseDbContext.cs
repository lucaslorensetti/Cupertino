using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cupertino.Core;
using Cupertino.Core.Common;
using Microsoft.EntityFrameworkCore;

namespace Cupertino.Data.Contexts.Base
{
    public class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IEntity
        {
            return await this.Set<TEntity>().AnyAsync(filter);
        }

        public async Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IEntity
        {
            return await this.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> ToListAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IEntity
        {
            return await this.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<TSelect>> ToListAsync<TEntity, TSelect>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TSelect>> selector)
            where TEntity : class, IEntity
        {
            return await this.Set<TEntity>().Where(filter).Select(selector).ToListAsync();
        }

        public async Task InsertAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            await this.Set<TEntity>().AddAsync(entity);
        }

        public Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task BeginTransactionAsync()
        {
            await this.Database.BeginTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await this.SaveChangesAsync();
        }

        public Task CommitTransactionAsync()
        {
            this.Database.CommitTransaction();
            return Task.CompletedTask;
        }

        public Task RollbackTransactionAsync()
        {
            this.Database.RollbackTransaction();
            return Task.CompletedTask;
        }

        public Task<bool> HasChangesAsync()
        {
            return Task.FromResult(this.ChangeTracker.HasChanges());
        }
    }
}

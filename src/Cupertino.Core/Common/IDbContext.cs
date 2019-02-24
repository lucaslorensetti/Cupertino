using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cupertino.Core.Common
{
    public interface IDbContext
    {
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IEntity;

        Task<TEntity> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> ToListAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class, IEntity;

        Task<IEnumerable<TSelect>> ToListAsync<TEntity, TSelect>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TSelect>> selector)
            where TEntity : class, IEntity;

        Task InsertAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<bool> HasChangesAsync();
    }
}

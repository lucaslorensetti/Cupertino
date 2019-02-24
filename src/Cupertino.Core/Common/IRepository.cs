using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cupertino.Core
{
    public interface IRepository<TEntity> 
        where TEntity : IEntity
    {
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TSelect>> GetManyAsync<TSelect>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TSelect>> selector);

        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

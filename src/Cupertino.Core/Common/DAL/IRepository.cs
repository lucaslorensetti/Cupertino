using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cupertino.Core
{
    public interface IRepository<TEntity> 
        where TEntity : IEntity
    {
        IQueryable<TEntity> GetQueryable();

        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

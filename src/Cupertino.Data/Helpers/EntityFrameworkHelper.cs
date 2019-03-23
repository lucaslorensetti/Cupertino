using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cupertino.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cupertino.Data.Helpers
{
    public static class EntityFrameworkHelper
    {
        public static async Task<List<TSource>> ToListAsync<TSource>(this IQueryable<TSource> source)
            where TSource : Entity
        {
            return await EntityFrameworkQueryableExtensions.ToListAsync(source);
        }

        public static async Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate = null)
            where TSource : Entity
        {
            if (predicate != null)
            {
                return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(source, predicate);
            }

            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(source);
        }

        public static async Task<bool> AnyAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
            where TSource : Entity
        {
            return await EntityFrameworkQueryableExtensions.AnyAsync(source, predicate);
        }
    }
}

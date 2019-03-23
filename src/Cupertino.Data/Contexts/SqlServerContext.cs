using System.Linq;
using System.Threading.Tasks;
using Cupertino.Core;
using Cupertino.Core.Common;
using Cupertino.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cupertino.Data.Contexts
{
    public class SqlServerContext : DbContext, IDbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<User> Users { get; set; }

        public IQueryable<TEntity> GetQueryable<TEntity>()
             where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
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

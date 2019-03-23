using Cupertino.Core;
using Cupertino.Data.Contexts;
using Cupertino.Data.Entities;

namespace Cupertino.Services.Tests.Mockers
{
    public class RepositoryMocker
    {
        private readonly SqlServerContext sqlServerContext;

        public RepositoryMocker()
        {
            //var options = new DbContextOptionsBuilder<DbContext>()
            //    .UseInMemoryDatabase("CupertinoInMemory")
            //    .Options;

            //this.sqlServerContext = new SqlServerContext(options);
            //this.sqlServerContext.Database.EnsureDeleted();
            //this.sqlServerContext.Database.EnsureCreated();
        }

        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : Entity
        {
            //return new Repository<TEntity>(this.sqlServerContext);
            return null;
        }
    }
}

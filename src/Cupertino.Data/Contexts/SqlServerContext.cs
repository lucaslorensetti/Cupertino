using Cupertino.Data.Contexts.Base;
using Cupertino.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cupertino.Data.Contexts
{
    public class SqlServerContext : BaseDbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

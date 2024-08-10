using HierarchyAPI.Role_Entity.Models.Config;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Castle.DynamicProxy;

using System.Security.Cryptography.X509Certificates;
using HierarchyAPI.Role_Entity.Interceptors;

namespace HierarchyAPI.Role_Entity.Models
{
    public class OrgaContext : DbContext
    {
        public OrgaContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Role> roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrgaContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.AddInterceptors(new LoggingInterceptor());
    }
}

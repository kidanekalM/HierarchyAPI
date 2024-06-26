using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HierarchyAPI.Models
{
    public class OrgaContext:DbContext
    {
        public OrgaContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Role> roles { get; set; }
    }
}

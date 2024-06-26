using Microsoft.EntityFrameworkCore;

namespace HierarchyAPI.Models
{
    public class OrgaContext:DbContext
    {
        public OrgaContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
    }
}

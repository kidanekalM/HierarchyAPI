using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HierarchyAPI.Models.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r=>r.Description).IsRequired();
            builder.Property(r=>r.Name).IsRequired();
            throw new NotImplementedException();
        }
    }
}

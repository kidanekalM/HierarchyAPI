using System.ComponentModel.DataAnnotations.Schema;

namespace HierarchyAPI.Models
{
    public class Role
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Parent")]
        public Guid? ParentId { get; set; }
        public Role? Parent { get; set; }
        public bool IsCandidate { get; set; }
    }
}

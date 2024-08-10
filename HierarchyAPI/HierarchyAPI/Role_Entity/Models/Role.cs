using System.ComponentModel.DataAnnotations.Schema;

namespace HierarchyAPI.Role_Entity.Models
{
    public class Role
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string? Role_Name { get; set; }
        public string? Role_Description { get; set; }
        [ForeignKey("Parent")]
        public Guid? Parent_Id { get; set; }
        public Role? Parent { get; set; }
        public bool Is_Candidate { get; set; }
    }
}

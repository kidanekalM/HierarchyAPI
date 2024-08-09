namespace HierarchyAPI.Models
{
    public class TreeNode
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TreeNode>? Children { get; set; }
        public TreeNode(Guid? Id,string? Name) 
        {
            this.Id = (Guid)Id!;
            this.Name = Name!;
        }
    }
}

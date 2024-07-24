using MediatR;

namespace HierarchyAPI.Models.Commands
{
    public class RemoveRecursiveCommand:IRequest<Role>
    {
        public Guid RoleId { get; set; }
    }
}

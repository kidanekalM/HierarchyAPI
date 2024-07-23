using MediatR;
namespace HierarchyAPI.Models.Commands
{
    public class RemoveCommand:IRequest<Role>
    {
        public Guid roleId { get; set; }
    }
}

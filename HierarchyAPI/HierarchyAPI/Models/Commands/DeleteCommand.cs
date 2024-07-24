using MediatR;

namespace HierarchyAPI.Models.Commands
{
    public class DeleteCommand:IRequest<Role>
    {
        public Guid Id { get; set; }
    }
}

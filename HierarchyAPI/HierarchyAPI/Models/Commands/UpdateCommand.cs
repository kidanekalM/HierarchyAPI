using MediatR;
namespace HierarchyAPI.Models.Commands
{
    public class UpdateCommand:IRequest<Role>
    {
        public Guid Id { get; set; }    
        public Role Role { get; set; }
    }
}

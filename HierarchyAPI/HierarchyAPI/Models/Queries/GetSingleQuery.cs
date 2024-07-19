using MediatR;
namespace HierarchyAPI.Models.Queries
{
    public class GetSingleQuery:IRequest<Role>
    {
        public Guid RoleId { get; set; }    
    }
}

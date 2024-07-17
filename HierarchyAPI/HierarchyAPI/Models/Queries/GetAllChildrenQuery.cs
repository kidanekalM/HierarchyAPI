using MediatR;
namespace HierarchyAPI.Models.Queries
{
    public class GetAllChildrenQuery:IRequest<List<Role>>
    {
        public Guid guid { get; set; }  
    }
}

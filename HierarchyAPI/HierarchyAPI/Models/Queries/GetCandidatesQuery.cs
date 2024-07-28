using MediatR;
using HierarchyAPI.Models.Repositories;

namespace HierarchyAPI.Models.Queries
{
    public class GetCandidatesQuery:IRequest<List<Role>>
    {
       public Guid RoleId { get; set; }  
    }
}


using MediatR;

namespace HierarchyAPI.Models.Queries
{
    public class GetAllRolesQuery:IRequest<List<Role>>
    {
    }
}

using MediatR;
using Dapper;
using HierarchyAPI.Models.Repositories;
namespace HierarchyAPI.Models.Queries
{
    public class GetAllRolesQuery:IRequest<List<Role>> { }
    public class GetAllRolesQueryHandler:IRequestHandler<GetAllRolesQuery,List<Role>>
    {
        private readonly IRoleQueryRepository _roleQueryRepository;
        public GetAllRolesQueryHandler(IRoleQueryRepository roleQueryRepository)
        {
            _roleQueryRepository = roleQueryRepository;
        }
        public async Task<List<Role>> Handle(GetAllRolesQuery getAllRolesQuery,CancellationToken cancellationToken)
        {
            return await _roleQueryRepository.GetAllRoles();
        }
    }
}

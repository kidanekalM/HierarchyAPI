using HierarchyAPI.Models.Repositories;
using MediatR;

namespace HierarchyAPI.Models.Queries
{
    public class GetCandidateQueryHandler:IRequestHandler<GetCandidatesQuery,List<Role>>
    {
        private readonly IRoleQueryRepository _repository;
        public GetCandidateQueryHandler(IRoleQueryRepository roleQueryRepository)
        {
            _repository = roleQueryRepository;
        }
        public async Task<List<Role>> Handle (GetCandidatesQuery request,CancellationToken cancellation)
        {
            return (await _repository.GetCandidates(request.RoleId)).ToList();
        }
    }
}

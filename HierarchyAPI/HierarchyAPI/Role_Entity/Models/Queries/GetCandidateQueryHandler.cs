using HierarchyAPI.Role_Entity.Models.Repositories;
using MediatR;

namespace HierarchyAPI.Role_Entity.Models.Queries
{
    public class GetCandidatesQuery : IRequest<List<Role>>
    {
        public Guid RoleId { get; set; }
    }
    public class GetCandidateQueryHandler : IRequestHandler<GetCandidatesQuery, List<Role>>
    {
        private readonly IRoleQueryRepository _repository;
        public GetCandidateQueryHandler(IRoleQueryRepository roleQueryRepository)
        {
            _repository = roleQueryRepository;
        }
        public async Task<List<Role>> Handle(GetCandidatesQuery request, CancellationToken cancellation)
        {
            return (await _repository.GetCandidates(request.RoleId)).ToList();
        }
    }
}

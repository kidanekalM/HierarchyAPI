using HierarchyAPI.Role_Entity.Models.Repositories;
using MediatR;

namespace HierarchyAPI.Role_Entity.Models.Commands
{
    public class DeleteByCandidateCommand : IRequest<Role>
    {
        public Guid Deleted { get; set; }
        public Guid Candidate { get; set; }
    }
    public class DeleteByCandidateCommandHandler : IRequestHandler<DeleteByCandidateCommand, Role>
    {
        private readonly IRoleCommandsRepository _roleCommandsRepository;
        public DeleteByCandidateCommandHandler(IRoleCommandsRepository roleCommandsRepository)
        {
            _roleCommandsRepository = roleCommandsRepository;
        }
        public async Task<Role> Handle(DeleteByCandidateCommand command, CancellationToken cancellationToken)
        {
            return await Assign(command);
        }
        async Task<Role> Assign(DeleteByCandidateCommand cmd)
        {
            var Deleted = await _roleCommandsRepository.GetSingle(cmd.Deleted);
            var candidate = await _roleCommandsRepository.GetSingle(cmd.Candidate);
            var children = await _roleCommandsRepository.GetAllChildren(cmd.Deleted);
            if (Deleted != null)
            {
                if (candidate != null)
                {
                    foreach (var child in children)
                    {
                        child.Parent = candidate;
                        child.Parent_Id = candidate.Id;
                        await _roleCommandsRepository.Update((Guid)child.Id, child);
                    }
                    candidate.Parent = Deleted.Parent;
                    candidate.Parent_Id = Deleted.Parent_Id;
                }
            }
            await _roleCommandsRepository.Remove(cmd.Deleted);
            return Deleted;
        }
    }
}

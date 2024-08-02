using HierarchyAPI.Models.Repositories;
using MediatR;

namespace HierarchyAPI.Models.Commands
{
    public class DeleteByCandidateCommandHandler:IRequestHandler<DeleteByCandidateCommand,Role>
    {
        private readonly IRoleCommandsRepository _roleCommandsRepository;
        private readonly IRoleQueryRepository _roleQueryRepository;
        public DeleteByCandidateCommandHandler(IRoleCommandsRepository roleCommandsRepository,IRoleQueryRepository roleQueryRepository)
        {
            _roleQueryRepository = roleQueryRepository; 
            _roleCommandsRepository = roleCommandsRepository;
        }
        public async Task<Role> Handle(DeleteByCandidateCommand command,CancellationToken cancellationToken)
        {
            return await Assign(command);
        }
        async Task<Role> Assign(DeleteByCandidateCommand cmd)
        {
            var Deleted = await _roleQueryRepository.GetSingle(cmd.Deleted);
            var candidate = await _roleQueryRepository.GetSingle(cmd.Candidate);
            var children = await _roleQueryRepository.GetAllChildren(cmd.Deleted);
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
                }
            }
            await _roleCommandsRepository.Remove(cmd.Deleted);
            return Deleted;
        }
    }
}

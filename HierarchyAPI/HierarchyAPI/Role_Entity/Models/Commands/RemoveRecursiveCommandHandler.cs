using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HierarchyAPI.Role_Entity.Models.Commands
{
    public class RemoveRecursiveCommand : IRequest<Role>
    {
        public Guid RoleId { get; set; }
    }
    public class RemoveRecursiveCommandHandler : IRequestHandler<RemoveRecursiveCommand, Role>
    {
        private readonly Repositories.IRoleCommandsRepository _repositoryCommandsRepository;
        public RemoveRecursiveCommandHandler(Repositories.IRoleCommandsRepository roleCommandsRepository)
        {
            _repositoryCommandsRepository = roleCommandsRepository;
        }
        public async Task<Role> Handle(RemoveRecursiveCommand removeRecursiveCommand, CancellationToken cancellationToken)
        {
            var role = await _repositoryCommandsRepository.RemoveRecursive(removeRecursiveCommand.RoleId);
            return role;
        }
    }
}

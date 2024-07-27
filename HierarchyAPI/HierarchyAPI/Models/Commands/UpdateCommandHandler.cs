using MediatR;
using System.Data;

namespace HierarchyAPI.Models.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand,Role>
    {
        private readonly Repositories.IRoleCommandsRepository _commandsRepository;
        public UpdateCommandHandler(Repositories.IRoleCommandsRepository roleCommandsRepository) 
        {
            _commandsRepository = roleCommandsRepository;
        }
        //check null 
        public async Task<Role> Handle(UpdateCommand command,CancellationToken cancellationToken)
        {
            Role role = await _commandsRepository.Update(command.Id,command.Role);
            return role;
        }
    }
}

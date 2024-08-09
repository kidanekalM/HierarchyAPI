using MediatR;
using System.Data;

namespace HierarchyAPI.Models.Commands
{
    public class UpdateCommand : IRequest<Role>
    {
        public Guid Id { get; set; }
        public string? Role_Name { get; set; }
        public string? Role_Description { get; set; }
        public Guid? Parent_Id { get; set; }
        public bool Is_Candidate { get; set; }
    }
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

            var rolToUpdate = new Role()
            {
                Id = command.Id,
                Role_Name = command.Role_Name,
                Role_Description = command.Role_Description,
                Parent_Id = command.Parent_Id,
                Is_Candidate = command.Is_Candidate,
            };
            Role role = await _commandsRepository.Update(command.Id,rolToUpdate);
            return role;
        }
    }
}

using Dapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace HierarchyAPI.Models.Commands
{
    public class DeleteCommandHandler:IRequestHandler<DeleteCommand,Role>
    {
        private readonly Repositories.IRoleQueryRepository roleQueryRepository;
        private readonly Repositories.IRoleCommandsRepository roleCommandRepository;
        public DeleteCommandHandler(Repositories.IRoleCommandsRepository roleCommandsRepository, Repositories.IRoleQueryRepository roleQueryRepository)
        {
            this.roleQueryRepository = roleQueryRepository;
            this.roleCommandRepository = roleCommandsRepository;
        }
        public async Task<Role> Handle(DeleteCommand deleteCommand,CancellationToken cancellationToken)
        {
            Role toDelte = await roleQueryRepository.GetSingle(deleteCommand.Id);
            List<Role> Children = await roleQueryRepository.GetAllChildren(deleteCommand.Id);
           if (((Children).Count != 0))
            {
                foreach (var child in Children)
                {
                    child.ParentId = toDelte.ParentId;
                    child.Parent = toDelte.Parent;
                    await roleCommandRepository.Update((Guid)child.Id,child);
                }
            }
           var role = await roleCommandRepository.Remove(deleteCommand.Id);

            return role;
        }
    }
}

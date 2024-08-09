using Dapper;
using HierarchyAPI.Models.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
namespace HierarchyAPI.Models.Commands
{
    public class DeleteCommand : IRequest<Role>
    {
        public Guid Id { get; set; }
    }
    public class DeleteCommandHandler:IRequestHandler<DeleteCommand,Role>
    {
        private readonly Repositories.IRoleCommandsRepository roleCommandRepository;
        public DeleteCommandHandler(Repositories.IRoleCommandsRepository roleCommandsRepository)
        {
            this.roleCommandRepository = roleCommandsRepository;
        }
        public async Task<Role> Handle(DeleteCommand deleteCommand,CancellationToken cancellationToken)
        {
            Role toDelte = await roleCommandRepository.GetSingle(deleteCommand.Id);
            List<Role> Children = await roleCommandRepository.GetAllChildren(deleteCommand.Id);
           if (((Children).Count != 0))
            {
                foreach (var child in Children)
                {
                    child.Parent_Id = toDelte.Parent_Id;
                    child.Parent = toDelte.Parent;
                    await roleCommandRepository.Update((Guid)child.Id,child);
                }
            }
           var role = await roleCommandRepository.Remove(deleteCommand.Id);

            return role;
        }
    }
}

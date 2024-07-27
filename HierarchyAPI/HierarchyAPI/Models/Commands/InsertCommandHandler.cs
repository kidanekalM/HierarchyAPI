using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
using System.Data;
namespace HierarchyAPI.Models.Commands
{
    public class InsertCommandHandler:IRequestHandler<InsertCommand,Role>
    {
        private readonly Repositories.IRoleCommandsRepository _repository;
        public InsertCommandHandler(Repositories.IRoleCommandsRepository roleCommandsRepository) 
        {
            _repository = roleCommandsRepository;
        }
        public async Task<Role> Handle(InsertCommand insertCommand,CancellationToken cancellationToken)
        {
            var role = await _repository.Insert(insertCommand.Role);
            return role;
        }
    }
}

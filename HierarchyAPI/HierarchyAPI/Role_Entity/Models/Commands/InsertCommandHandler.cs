using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace HierarchyAPI.Role_Entity.Models.Commands
{
    public class InsertCommand : IRequest<Role>
    {
        public string? Role_Name { get; set; }
        public string? Role_Description { get; set; }
        public Guid? Parent_Id { get; set; }
        public bool Is_Candidate { get; set; }
    }
    public class InsertCommandHandler : IRequestHandler<InsertCommand, Role>
    {

        private readonly Repositories.IRoleCommandsRepository _repository;
        public InsertCommandHandler(Repositories.IRoleCommandsRepository roleCommandsRepository)
        {
            _repository = roleCommandsRepository;
        }
        public async Task<Role> Handle(InsertCommand insertCommand, CancellationToken cancellationToken)
        {
            Role role = new Role
            {
                Id = Guid.NewGuid(),
                Role_Name = insertCommand.Role_Name,
                Role_Description = insertCommand.Role_Description,
                Parent_Id = insertCommand.Parent_Id,
                Is_Candidate = insertCommand.Is_Candidate
            };
            return await _repository.Insert(role);
        }
    }
}

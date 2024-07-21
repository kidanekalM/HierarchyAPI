using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
using System.Data;
namespace HierarchyAPI.Models.Commands
{
    public class InsertCommandHandler:IRequestHandler<InsertCommand,Role>
    {
        private readonly OrgaContext _context;
        public InsertCommandHandler(OrgaContext orgaContext) 
        {
            _context = orgaContext;
        }
        public async Task<Role> Handle(InsertCommand insertCommand,CancellationToken cancellationToken)
        {
            _context.roles.Add(insertCommand.Role);
            _context.SaveChanges();
            return insertCommand.Role;
        }
    }
}

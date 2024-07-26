using MediatR;
using System.Data;

namespace HierarchyAPI.Models.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand,Role>
    {
        private readonly OrgaContext _context;
        public UpdateCommandHandler(OrgaContext orgaContext) 
        {
            _context = orgaContext;
        }
        //check null 
        public async Task<Role> Handle(UpdateCommand command,CancellationToken cancellationToken)
        {
            Role role = command.Role;
            var oldRole = _context.roles.FirstOrDefault(r => r.Id.Equals(command.Id));
            oldRole.Description = role.Description;
            oldRole.Name = role.Name;
            oldRole.Parent = _context.roles.FirstOrDefault(r => r.Id.Equals(role.ParentId));
            oldRole.ParentId = role.ParentId;
            _context.roles.Update(oldRole);
            _context.SaveChanges();
            return role;
        }
    }
}

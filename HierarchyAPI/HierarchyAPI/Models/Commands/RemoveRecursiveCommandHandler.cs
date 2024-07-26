using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HierarchyAPI.Models.Commands
{
    public class RemoveRecursiveCommandHandler:IRequestHandler<RemoveRecursiveCommand,Role>
    {
        private readonly OrgaContext _OrgaContext;
        public RemoveRecursiveCommandHandler(OrgaContext orgaContext)
        {
            _OrgaContext = orgaContext;
        }
        public async Task<Role> RemoveRecursiveNonAction(List<Role> Roles, Guid roleId)
        {
            Role toDelte = Roles.Where(r => r.Id.Equals(roleId)).FirstOrDefault();
            List<Role> Children = Roles.Where(r => r.ParentId.Equals(roleId)).ToList();
            if (Children.Count != 0)
            {
                foreach (var child in Children)
                {
                    RemoveRecursiveNonAction(Roles, (Guid)child.Id);
                }
            }
            var role = Roles.FirstOrDefault(r => r.Id.Equals(roleId));
            _OrgaContext.roles.Remove(role);
            return role;
        }
        public async Task<Role> Handle(RemoveRecursiveCommand removeRecursiveCommand, CancellationToken cancellationToken)
        {
            var role = await RemoveRecursiveNonAction(_OrgaContext.roles.ToList(), removeRecursiveCommand.RoleId);
            _OrgaContext.SaveChanges();
            return role;
        }
    }
}

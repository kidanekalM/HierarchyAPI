using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HierarchyAPI.Models.Repositories
{
    public class RoleCommandsRepository:IRoleCommandsRepository
    {
        private readonly OrgaContext _OrgaContext;
        public RoleCommandsRepository(OrgaContext orgaContext)
        {
            _OrgaContext = orgaContext;
        }
        public async Task<Role> Insert(Role role)
        {
            _OrgaContext.roles.Add(role);
            _OrgaContext.SaveChanges();
            return role;
        }
        public async Task<Role> Remove(Guid roleId)
        {
            var role = await _OrgaContext.roles.FirstOrDefaultAsync(r => r.Id == roleId);
            _OrgaContext.roles.Remove(role);
            await _OrgaContext.SaveChangesAsync();
            return role;
        }
        public async Task<Role> RemoveRecursive(Guid roleId)
        {
            var role = await RemoveRecursiveNonAction(_OrgaContext.roles.ToList(), roleId);
            _OrgaContext.SaveChanges();
            return role;
        }
        [NonAction]
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
        public async Task<Role> Update(Guid roleId, Role role)
        {
            var oldRole = _OrgaContext.roles.FirstOrDefault(r => r.Id.Equals(roleId));
            oldRole.Description = role.Description;
            oldRole.Name = role.Name;
            oldRole.Parent = _OrgaContext.roles.FirstOrDefault(r => r.Id.Equals(oldRole.ParentId));
            oldRole.ParentId = role.ParentId;
            _OrgaContext.roles.Update(oldRole);
            _OrgaContext.SaveChanges();
            return role;
        }
    }
}

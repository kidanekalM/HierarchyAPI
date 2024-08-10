using HierarchyAPI.Role_Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HierarchyAPI.Role_Entity.Models.Repositories
{
    public class RoleCommandsRepository : IRoleCommandsRepository
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
        public async Task<Role> RemoveRecursiveNonAction(List<Role> Roles, Guid roleId)
        {
            Role? toDelte = Roles.FirstOrDefault(r => r.Id.Equals(roleId));
            List<Role> Children = Roles.Where(r => r.Parent_Id.Equals(roleId)).ToList();
            if (Children.Count != 0)
            {
                foreach (var child in Children)
                {
                    await RemoveRecursiveNonAction(Roles, (Guid)child.Id);
                }
            }
            var role = Roles.FirstOrDefault(r => r.Id.Equals(roleId));
            _OrgaContext.roles.Remove(role);
            return role;
        }
        public async Task<Role> Update(Guid roleId, Role role)
        {
            var oldRole = _OrgaContext.roles.FirstOrDefault(r => r.Id.Equals(roleId));
            oldRole.Role_Description = role.Role_Description;
            oldRole.Role_Name = role.Role_Name;
            oldRole.Parent = _OrgaContext.roles.FirstOrDefault(r => r.Id.Equals(oldRole.Parent_Id));
            oldRole.Parent_Id = role.Parent_Id;
            _OrgaContext.roles.Update(oldRole);
            _OrgaContext.SaveChanges();
            return role;
        }
        public async Task<Role> GetSingle(Guid roleId)
        {
            return await _OrgaContext.roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }
        public async Task<List<Role>> GetAllRoles()
        {
            return await _OrgaContext.roles.ToListAsync();
        }
        public async Task<List<Role>> GetAllChildren(Guid roleId)
        {
            return await _OrgaContext.roles.Where(r => r.Parent_Id == roleId).ToListAsync();
        }
        //Add get
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HierarchyAPI.Models
{
    public class RoleRepository:IRoleRepository
    {
        private readonly OrgaContext _OrgaContext;
        public RoleRepository( OrgaContext orgaContext ) 
        {
            _OrgaContext = orgaContext;
        }
        public async Task<Role> Insert(Role role)
        {
            _OrgaContext.roles.Add( role );
            _OrgaContext.SaveChanges();
            return role;
        }
        public async Task<Role> Remove(Guid roleId)
        {
            var role = _OrgaContext.roles.FirstOrDefault<Role>(r => r.Id.Equals(roleId));
            _OrgaContext.roles.Remove(role) ;
            _OrgaContext.SaveChanges();
            return role;
        }

        public async Task<Role> Update(Guid roleId, Role role)
        {
            var oldRole = _OrgaContext.roles.FirstOrDefault<Role>(r => r.Id.Equals(roleId));
            oldRole.Description = role.Description;
            oldRole.Name = role.Name;
            oldRole.Parent = _OrgaContext.roles.FirstOrDefault<Role>(r => r.Id.Equals(oldRole.ParentId));
            oldRole.ParentId = role.ParentId;
            _OrgaContext.roles.Update( role);
            _OrgaContext.SaveChanges();
            return role;
        }
        public async Task<List<Role>> GetAllChildren(Guid roleId)
        {
            return _OrgaContext.roles.Where(r=>r.ParentId.Equals(roleId)).ToList();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return _OrgaContext.roles.ToList();
        }

        public async Task<Role> GetSingle(Guid roleId)
        {
            return _OrgaContext.roles.FirstOrDefault();
        }


    }
}

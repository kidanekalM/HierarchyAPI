using Microsoft.AspNetCore.Mvc;

namespace HierarchyAPI.Role_Entity.Models.Repositories
{
    public interface IRoleRepository
    {
        public Task<Role> Insert(Role role);
        public Task<Role> Update(Guid guid, Role role);
        public Task<Role> Remove(Guid roleId);
        public Task<Role> RemoveRecursive(Guid roleId);
        public Task<List<Role>> GetAllRoles();
        public Task<Role> GetSingle(Guid roleId);
        public Task<List<Role>> GetAllChildren(Guid roleId);
    }
}

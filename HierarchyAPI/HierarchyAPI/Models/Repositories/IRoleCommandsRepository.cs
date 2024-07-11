namespace HierarchyAPI.Models.Repositories
{
    public interface IRoleCommandsRepository
    {
        public Task<Role> Insert(Role role);
        public Task<Role> Update(Guid guid, Role role);
        public Task<Role> Remove(Guid roleId);
        public Task<Role> RemoveRecursive(Guid roleId);
    }
}

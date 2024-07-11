namespace HierarchyAPI.Models.Repositories
{
    public interface IRoleQueryRepository
    {
        public Task<List<Role>> GetAllRoles();
        public Task<Role> GetSingle(Guid roleId);
        public Task<List<Role>> GetAllChildren(Guid roleId);
    }
}

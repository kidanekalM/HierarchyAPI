using HierarchyAPI.Role_Entity.Models;

namespace HierarchyAPI.Role_Entity.Models.Repositories
{
    public interface IRoleQueryRepository
    {
        public Task<List<Role>> GetAllRoles();
        public Task<Role> GetSingle(Guid roleId);
        public Task<List<Role>> GetAllChildren(Guid roleId);
        public Task<List<Role>> GetCandidates(Guid roleId);
        public Task<TreeNode> Tree(Guid roleId);
    }
}

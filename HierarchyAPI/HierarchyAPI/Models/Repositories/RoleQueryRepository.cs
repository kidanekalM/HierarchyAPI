using Dapper;

namespace HierarchyAPI.Models.Repositories
{
    public class RoleQueryRepository:IRoleQueryRepository
    {
        private readonly OrgaContext _OrgaContext;
        private readonly DapperContext _DapperContext;
        public RoleQueryRepository(OrgaContext orgaContext, DapperContext dapperContext)
        {
            _OrgaContext = orgaContext;
            _DapperContext = dapperContext;
        }
        public async Task<List<Role>> GetAllChildren(Guid roleId)
        {
            return _OrgaContext.roles.Where(r => r.ParentId.Equals(roleId)).ToList();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return _OrgaContext.roles.ToList();
        }

        public async Task<Role> GetSingle(Guid roleId)
        {
            return _OrgaContext.roles.FirstOrDefault(r => r.Id.Equals(roleId));
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var query = "SELECT * FROM Roles";

            using (var connection = _DapperContext.CreateConnection())
            {
                var roles = await connection.QueryAsync<Role>(query);
                return roles.ToList();
            }
        }
    }
}

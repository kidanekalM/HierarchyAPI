using Dapper;

namespace HierarchyAPI.Models.Repositories
{
    public class RoleQuery:IRoleQueryRepository
    {
        private readonly DapperContext _DapperContext;
        public RoleQuery(DapperContext dapperContext)
        {
            _DapperContext = dapperContext;
        }
        public async Task<List<Role>> GetAllChildren(Guid roleId)
        {
            var query = "SELECT * FROM public.\"role_table\" WHERE \"parent_id\" = @RoleId";

            using (var connection = _DapperContext.CreateConnection())
            {
                var children = await connection.QueryAsync<Role>(query, new { RoleId = roleId });
                return children.ToList();
            }
        }
        public async Task<List<Role>> GetAllRoles()
        {
            var query = "SELECT * FROM public.\"role_table\"";

            using (var connection = _DapperContext.CreateConnection())
            {
                var roles = await connection.QueryAsync<Role>(query);
                return roles.ToList();
            }
        }
        public async Task<Role> GetSingle(Guid roleId)
        {
            var query = "SELECT * FROM public.\"role_table\" WHERE public.\"role_table\".\"Id\" = @RoleId";

            using (var connection = _DapperContext.CreateConnection())
            {
                var role = (await connection.QueryAsync<Role>(query, new { RoleId = roleId })).FirstOrDefault();
                return role;
            }
        }
        public async Task<List<Role>> GetCandidates(Guid roleId)
        {
            var query = "SELECT * FROM public.\"role_table\" WHERE \"parent_id\" = @RoleId AND is_candidate = true";

            using (var connection = _DapperContext.CreateConnection())
            {
                var children = await connection.QueryAsync<Role>(query, new { RoleId = roleId });
                return children.ToList();
            }
        }

    }
}

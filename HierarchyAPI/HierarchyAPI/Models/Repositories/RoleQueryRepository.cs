using Dapper;

namespace HierarchyAPI.Models.Repositories
{
    public class RoleQueryRepository:IRoleQueryRepository
    {
        private readonly DapperContext _DapperContext;
        public RoleQueryRepository(DapperContext dapperContext)
        {
            _DapperContext = dapperContext;
        }
        public async Task<List<Role>> GetAllChildren(Guid roleId)
        {
            var query = "SELECT * FROM public.\"Role_Table\" WHERE \"ParentId\" = @RoleId";

            using (var connection = _DapperContext.CreateConnection())
            {
                var children = await connection.QueryAsync<Role>(query, new { RoleId = roleId });
                return children.ToList();
            }
        }
        public async Task<List<Role>> GetAllRoles()
        {
            var query = "SELECT * FROM public.\"Role_Table\"";

            using (var connection = _DapperContext.CreateConnection())
            {
                var roles = await connection.QueryAsync<Role>(query);
                return roles.ToList();
            }
        }
        public async Task<Role> GetSingle(Guid roleId)
        {
            var query = "SELECT * FROM public.\"Role_Table\" WHERE public.\"Role_Table\".\"Id\" = @RoleId";

            using (var connection = _DapperContext.CreateConnection())
            {
                var role = (await connection.QueryAsync<Role>(query, new { RoleId = roleId })).FirstOrDefault();
                return role;
            }
        }

    }
}

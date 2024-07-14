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
            var query = "SELECT * FROM public.\"Role_Table\" WHERE ParentId=\""+roleId+"\"";

            using (var connection = _DapperContext.CreateConnection())
            {
                var children = await connection.QueryAsync<Role>(query);
                return children.ToList();
            }
            return _OrgaContext.roles.Where(r => r.ParentId.Equals(roleId)).ToList();
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
            var query = "SELECT * FROM public.\"Role_Table\" WHERE public.\"Role_Table\".\"Id\" = \"" + roleId + "\"";

            using (var connection = _DapperContext.CreateConnection())
            {
                var role = (await connection.QueryAsync<Role>(query)).FirstOrDefault();
                return role;
            }
            return _OrgaContext.roles.FirstOrDefault(r => r.Id.Equals(roleId));
        }

    }
}

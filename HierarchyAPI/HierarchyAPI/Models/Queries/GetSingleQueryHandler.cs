using MediatR;
using Dapper;
namespace HierarchyAPI.Models.Queries
{
    public class GetSingleQueryHandler : IRequestHandler<GetSingleQuery,Role>
    {
        private readonly DapperContext _dapperContext;
        public GetSingleQueryHandler(DapperContext dapperContext) 
        {
            _dapperContext = dapperContext;
        }
        public async Task<Role> Handle(GetSingleQuery getSingleQuery, CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM public.\"Role_Table\" WHERE public.\"Role_Table\".\"Id\" = @RoleId";

            using (var connection = _dapperContext.CreateConnection())
            {
                var role = (await connection.QueryAsync<Role>(query, new { RoleId = getSingleQuery.RoleId })).FirstOrDefault();
                return role;
            }
        }
    }
}

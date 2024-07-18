using MediatR;
using Dapper;
namespace HierarchyAPI.Models.Queries
{
    public class GetAllRolesQueryHandler:IRequestHandler<GetAllRolesQuery,List<Role>>
    {
        private readonly DapperContext dapperContext;
        public GetAllRolesQueryHandler(DapperContext context)
        {
            dapperContext = context;
        }
        public async Task<List<Role>> Handle(GetAllRolesQuery getAllRolesQuery,CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM public.\"Role_Table\"";

            using (var connection = dapperContext.CreateConnection())
            {
                var roles = await connection.QueryAsync<Role>(query);
                return roles.ToList();
            }
        }
    }
}

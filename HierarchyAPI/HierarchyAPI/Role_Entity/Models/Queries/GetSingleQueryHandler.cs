using MediatR;
using Dapper;
using HierarchyAPI.Role_Entity.Models;
namespace HierarchyAPI.Role_Entity.Models.Queries
{
    public class GetSingleQuery : IRequest<Role>
    {
        public Guid RoleId { get; set; }
    }
    public class GetSingleQueryHandler : IRequestHandler<GetSingleQuery, Role>
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
                var role = (await connection.QueryAsync<Role>(query, new { getSingleQuery.RoleId })).FirstOrDefault();
                return role;
            }
        }
    }
}

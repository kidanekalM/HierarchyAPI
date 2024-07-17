using Azure.Core;
using Dapper;
using MediatR;
using System.Reflection.Metadata;
namespace HierarchyAPI.Models.Queries
{
    public class GetAllChildrenQueryHandler:IRequestHandler<GetAllChildrenQuery, List<Role>>
    {
        public DapperContext _dapperContext;
        public GetAllChildrenQueryHandler(DapperContext context)
        {
            _dapperContext = context;
        }
        public async Task<List<Role>> Handle(GetAllChildrenQuery request,CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM public.\"Role_Table\" WHERE \"ParentId\" = @RoleId";

            using (var connection = _dapperContext.CreateConnection())
            {
                var children = await connection.QueryAsync<Role>(query, new { RoleId = request.guid});
                return children.ToList();
            }
        }
    }
}

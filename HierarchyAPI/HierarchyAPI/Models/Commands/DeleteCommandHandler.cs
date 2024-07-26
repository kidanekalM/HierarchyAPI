using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace HierarchyAPI.Models.Commands
{
    public class DeleteCommandHandler:IRequestHandler<DeleteCommand,Role>
    {
        private readonly OrgaContext _context;
        private readonly DapperContext _DapperContext;
        public DeleteCommandHandler(OrgaContext orgaContext,DapperContext dapperContext)
        {
            _context = orgaContext;
            _DapperContext = dapperContext;
        }
        public async Task<Role> Handle(DeleteCommand deleteCommand,CancellationToken cancellationToken)
        {
            var query = "SELECT * FROM public.\"Role_Table\" WHERE public.\"Role_Table\".\"Id\" = @RoleId";
            Role toDelte;
            List<Role> Children;
            using (var connection = _DapperContext.CreateConnection())
            {
                var rol = (await connection.QueryAsync<Role>(query, new { RoleId = deleteCommand.Id })).FirstOrDefault();
                toDelte = rol;
            }
            Children = _context.roles.Where(r=>r.ParentId==deleteCommand.Id).ToList();
           if (((Children).Count != 0))
            {
                foreach (var child in Children)
                {
                    child.ParentId = toDelte.ParentId;
                    child.Parent = toDelte.Parent;
                }
            }
            var role = await _context.roles.FirstOrDefaultAsync(r => r.Id == deleteCommand.Id);
            _context.roles.Remove(role);
            await _context.SaveChangesAsync();
            return role;
        }
    }
}

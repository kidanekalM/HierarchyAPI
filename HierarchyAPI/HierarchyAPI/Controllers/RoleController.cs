using HierarchyAPI.Models;
using HierarchyAPI.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using HierarchyAPI.Models.Queries;
using HierarchyAPI.Models.Commands;
namespace HierarchyAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly IRoleCommandsRepository _roleCommandsRepository;
        private readonly IMediator _mediator;
        public RoleController(IRoleQueryRepository roleQueryRepository,IRoleCommandsRepository roleCommandsRepository,IMediator mediator)
        {
            _roleQueryRepository = roleQueryRepository;
            _roleCommandsRepository = roleCommandsRepository;
            _mediator = mediator;
        }
        //Accept cmd
        [HttpPost("Insert")]
        public async Task<Role> Insert(InsertCommand insertCommand)
        {
            return await _mediator.Send(insertCommand);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Role>> Update(UpdateCommand updateCommand)
        {
            return await _mediator.Send(updateCommand);
        }
        [HttpDelete("Delete")]
        public async Task<Role> Remove(DeleteCommand deleteCommand)
        {
            return await _mediator.Send(deleteCommand);
        }
        [HttpDelete("DeleteRecursive")]
        public async Task<ActionResult<Role>> RemoveRecursive(RemoveRecursiveCommand removeRecursiveCommand)
        {
            return await _mediator.Send(removeRecursiveCommand);
        }
        [HttpGet("GetAllChildren")]
        public async Task<ActionResult<List<Role>>> GetAllChildren(GetAllChildrenQuery getAllChildrenQuery)
        {
            var children = await _mediator.Send(getAllChildrenQuery);

            return Ok(children);
        }
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            var roles =  await _mediator.Send(new GetAllRolesQuery());
            return roles;
        }
        [HttpGet("GetSingle")]
        public async Task<Role> GetSingle(GetSingleQuery getSingleQuery)
        {
            return await _mediator.Send(getSingleQuery);
        }
        [HttpGet("Tree")]
        public async Task<TreeNode> Tree(Guid roleId)
        {
            List<Role> roles = await _mediator.Send(new GetAllRolesQuery());
            return await GenerateTree(roles, roleId);
        }
        [NonAction]
        public async Task<TreeNode> GenerateTree(List<Role> roles, Guid? roleId)
        {
            TreeNode RootNode;
            if (roleId == null)
            {
                var Root = roles.Find(r => r.ParentId == null);
                roleId = Root.Id;
                RootNode = new TreeNode(Root.Id, Root.Name);
            }
            else
            {
                var Root = roles.Find(r => r.Id == roleId);
                RootNode = new TreeNode(Root.Id, Root.Name);
            }
            List<Role> Children = roles.FindAll(r => r.ParentId == roleId);
            RootNode.Children = new List<TreeNode>();
            foreach (var child in Children)
            {
                TreeNode childNode = await GenerateTree(roles, (Guid)child.Id);
                RootNode.Children.Add(childNode);
            }
            return RootNode;
        }
    }
}
